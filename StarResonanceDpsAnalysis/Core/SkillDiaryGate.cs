using StarResonanceDpsAnalysis.Forms;
using StarResonanceDpsAnalysis.Plugin.DamageStatistics;
using StarResonanceDpsAnalysis.Plugin;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace StarResonanceDpsAnalysis.Core
{
    internal static class SkillDiaryGate
    {
        private class PendingEntry
        {
            public long StartTick;      // ★ Added: window start timestamp
            public long LastTick;       // Timestamp of the last record
            public int Count;           // Accumulated count within the current window
            public ulong TotalDamage;   // Accumulated damage within the current window
            public int CritCount;       // ★ Added: accumulated critical hits in the window
            public int LuckyCount;      // ★ Added: accumulated lucky hits in the window
        }

        // Merge only by (player, skill ID), variants are not handled
        private static readonly ConcurrentDictionary<(ulong Uid, ulong SkillId, bool Treat), PendingEntry> _pending = new();

        // Window threshold (ms): only accumulate within the window, no output;
        // a gap > WindowMs causes a “natural break”
        private const int WindowMs = 700;

        // Maximum hold duration (ms): even if it never “breaks”,
        // force output when this duration is reached
        private const int MaxHoldMs = 1000;

        private static double TicksPerMs => Stopwatch.Frequency / 1000.0;

        /// <summary>
        /// Record one “skill hit” for skill diary merging.
        /// Returns (shouldWrite, countToOutput, damageToOutput),
        /// indicating whether the “previous segment” should be written out.
        /// </summary>
        public static (bool shouldWrite, int countToOutput, ulong damageToOutput, int critToOutput, int luckyToOutput)
      Register(ulong uid, ulong skillId, ulong damage, bool isCrit, bool isLucky, bool treat)
        {
            long now = Stopwatch.GetTimestamp();
            long windowTicks = (long)(WindowMs * TicksPerMs);
            long holdTicks = (long)(MaxHoldMs * TicksPerMs);
            var key = (uid, skillId, treat);   // ★ Key

            var entry = _pending.GetOrAdd(key, _ => new PendingEntry
            {
                StartTick = now,
                LastTick = now,
                Count = 0,
                TotalDamage = 0,
                CritCount = 0,
                LuckyCount = 0
            });

            lock (entry)
            {
                long dtSinceLast = now - entry.LastTick;
                long dtSinceStart = now - entry.StartTick;

                if (entry.Count == 0)
                {
                    entry.Count = 1;
                    entry.TotalDamage = damage;
                    entry.CritCount = isCrit ? 1 : 0;
                    entry.LuckyCount = isLucky ? 1 : 0;
                    entry.StartTick = now;
                    entry.LastTick = now;
                    return (false, 0, 0, 0, 0);
                }

                if (dtSinceLast <= windowTicks && dtSinceStart < holdTicks)
                {
                    entry.Count++;
                    entry.TotalDamage += damage;
                    if (isCrit) entry.CritCount++;
                    if (isLucky) entry.LuckyCount++;
                    entry.LastTick = now;
                    return (false, 0, 0, 0, 0);
                }

                // Need to write out the previous segment
                int outCount = entry.Count;
                ulong outDmg = entry.TotalDamage;
                int outCrit = entry.CritCount;
                int outLucky = entry.LuckyCount;

                // Treat the current hit as the start of a new segment
                entry.Count = 1;
                entry.TotalDamage = damage;
                entry.CritCount = isCrit ? 1 : 0;
                entry.LuckyCount = isLucky ? 1 : 0;
                entry.StartTick = now;
                entry.LastTick = now;

                return (true, outCount, outDmg, outCrit, outLucky);
            }
        }


        /// <summary>
        /// Called in the “hit event”: merge multiple segments by (uid, skillId),
        /// and write to the diary when the window breaks.
        /// - Only records when the skill diary window exists and it is “my own” event (uid == AppConfig.Uid);
        /// - Uses SkillDiaryGate.Register for window merging;
        /// - Writes one line when the window breaks (single segment or “skill * count”), including damage info.
        /// </summary>
        /// <param name="uid">UID of the player for this hit</param>
        /// <param name="skillId">Skill ID (no variant merging)</param>
        /// <param name="damage">Damage value of this hit (used for window accumulation and single-segment display)</param>
        /// <param name="iscrit">Whether it is a critical hit</param>
        /// <param name="isLucky">Whether it is a lucky hit</param>
        /// <param name="treat">Whether it is healing</param>
        public static void OnHit(ulong uid, ulong skillId, ulong damage, bool iscrit, bool isLucky, bool treat = false)
        {
            // 1) Only process my own events
            if (uid != AppConfig.Uid) return;

            // 2) Take a local snapshot to avoid it being nulled by another thread after checking
            var form = FormManager.skillDiary;
            if (form == null || form.IsDisposed || !form.IsHandleCreated) return;

            var (shouldWrite, count, totalDamage, critCount, luckyCount) =
                SkillDiaryGate.Register(uid, skillId, damage, iscrit, isLucky, treat); // ★ Pass treat

            if (!shouldWrite || count <= 0) return;

            var duration = StatisticData._manager.GetFormattedCombatDuration();
            if (FormManager.showTotal) duration = FullRecord.GetEffectiveDurationString();

            var name = EmbeddedSkillConfig.GetName(skillId.ToString());

            string line;
            if (count > 1)
            {
                // Multiple segments
                var parts = new List<string>
            {
                $"{name}",
                $"{(treat ? "Healing" : "Damage")}:{totalDamage}",
                $"Casts:{count}"
            };
                if (critCount > 0) parts.Add($"Critical:{critCount}");
                if (luckyCount > 0) parts.Add($"Lucky:{luckyCount}");

                line = $"[{duration}] " + string.Join(" | ", parts);
            }
            else
            {
                // Single segment
                var parts = new List<string>
                {
                    $"{name}",
                    $"{(treat ? "Healing" : "Damage")}:{damage}"
                };
                if (iscrit) parts.Add("Critical");
                if (isLucky) parts.Add("Lucky");

                line = $"[{duration}] " + string.Join(" | ", parts);
            }



            FormManager.skillDiary.AppendDiaryLine(line);
        }



        /// <summary>
        /// Periodic flush: write out segments that have not continued for longer than WindowMs
        /// (to avoid waiting forever for the next hit).
        /// Recommended to call from your 1s timer.
        /// </summary>
        public static IEnumerable<(ulong Uid, ulong SkillId, int Count, ulong Damage)>
            DrainStalePending()
        {
            long now = Stopwatch.GetTimestamp();
            long windowTicks = (long)(WindowMs * TicksPerMs);

            foreach (var kv in _pending)
            {
                var entry = kv.Value;
                lock (entry)
                {
                    if (entry.Count > 0 && (now - entry.LastTick) > windowTicks)
                    {
                        var outCount = entry.Count;
                        var outDmg = entry.TotalDamage;
                        entry.Count = 0;
                        entry.TotalDamage = 0;
                        // Note: Start/Last are not reset; this entry will be reused on the next Register call
                        yield return (kv.Key.Uid, kv.Key.SkillId, outCount, outDmg);
                    }
                }
            }
        }
        /// <summary>
        /// Called when clearing the field / ending combat:
        /// flush all segments still in the window at once
        /// (then the caller writes them into the diary).
        /// After returning, these segments are cleared but dictionary entries are not removed;
        /// call Reset() if a full clear is needed.
        /// </summary>
        public static IEnumerable<(ulong Uid, ulong SkillId, int Count, ulong Damage)>
            DrainAllPending()
        {
            foreach (var kv in _pending)
            {
                var entry = kv.Value;
                lock (entry)
                {
                    if (entry.Count > 0)
                    {
                        var outCount = entry.Count;
                        var outDmg = entry.TotalDamage;
                        entry.Count = 0;
                        entry.TotalDamage = 0;
                        yield return (kv.Key.Uid, kv.Key.SkillId, outCount, outDmg);
                    }
                }
            }
        }

        /// <summary>
        /// Completely clear internal cache (unwritten segments will be discarded).
        /// Generally, call DrainAllPending() to flush first, then call Reset().
        /// </summary>
        public static void Reset() => _pending.Clear();


    }
}
