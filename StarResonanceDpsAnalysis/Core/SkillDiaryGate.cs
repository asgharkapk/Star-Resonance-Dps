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
            public long StartTick;      // ★ جدید: زمان شروع پنجره
            public long LastTick;       // آخرین زمان ثبت شده
            public int Count;           // تعداد تجمعی در پنجره فعلی
            public ulong TotalDamage;   // مجموع آسیب در پنجره فعلی
            public int CritCount;       // ★ جدید: تعداد ضربه بحرانی تجمعی در پنجره
            public int LuckyCount;      // ★ جدید: تعداد خوش‌شانسی تجمعی در پنجره
        }

        // فقط بر اساس (بازیکن، شناسه مهارت) ترکیب می‌شود، تغییرات را پردازش نمی‌کند
        private static readonly ConcurrentDictionary<(ulong Uid, ulong SkillId, bool Treat), PendingEntry> _pending = new();

        // آستانه پنجره (میلی‌ثانیه): فقط تجمعی است و خروجی نمی‌دهد؛ اگر فاصله >WindowMs باشد "قطع طبیعی" رخ می‌دهد
        private const int WindowMs = 700;

        // حداکثر طول نگه‌داری تک‌مرحله‌ای (میلی‌ثانیه): حتی اگر پیوسته باشد، پس از این مدت اجباری نوشته می‌شود
        private const int MaxHoldMs = 1000;

        private static double TicksPerMs => Stopwatch.Frequency / 1000.0;

        /// <summary>
        /// ثبت یک "اصابت مهارت" برای ترکیب در دفترچه مهارت.
        /// بازگشت (shouldWrite, countToOutput, damageToOutput) برای مشخص کردن نیاز به نوشتن "مرحله قبل".
        /// </summary>
        public static (bool shouldWrite, int countToOutput, ulong damageToOutput, int critToOutput, int luckyToOutput)
      Register(ulong uid, ulong skillId, ulong damage, bool isCrit, bool isLucky, bool treat)
        {
            long now = Stopwatch.GetTimestamp();
            long windowTicks = (long)(WindowMs * TicksPerMs);
            long holdTicks = (long)(MaxHoldMs * TicksPerMs);
            var key = (uid, skillId, treat);   // ★ کلیدی

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

                // نیاز به نوشتن مرحله قبل
                int outCount = entry.Count;
                ulong outDmg = entry.TotalDamage;
                int outCrit = entry.CritCount;
                int outLucky = entry.LuckyCount;

                // مرحله جدید به عنوان سر جدید
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
        /// فراخوانی در "رویداد اصابت": ترکیب چند مرحله بر اساس (uid, skillId) و نوشتن دفترچه هنگام قطع پنجره.
        /// - فقط وقتی پنجره skillDiary وجود دارد و رویداد "خودم" است (uid == AppConfig.Uid) ثبت می‌شود؛
        /// - از SkillDiaryGate.Register برای ترکیب پنجره استفاده شود؛
        /// - هنگام قطع پنجره، یک خط نوشته می‌شود (تک‌مرحله‌ای یا "مهارت * تعداد") همراه با اطلاعات آسیب.
        /// </summary>
        /// <param name="uid">UID بازیکن مرتبط با این اصابت</param>
        /// <param name="skillId">شناسه مهارت (تغییرات ترکیب نمی‌شوند)</param>
        /// <param name="damage">مقدار آسیب این اصابت (برای جمع به مجموع پنجره و نمایش تک‌مرحله‌ای)</param>
        /// <param name="iscrit">آیا ضربه بحرانی است</param>
        /// <param name="isLucky">آیا خوش‌شانسی است</param>
        /// <param name="treat">آیا درمان است</param>
        public static void OnHit(ulong uid, ulong skillId, ulong damage, bool iscrit, bool isLucky, bool treat = false)
        {
            // 1) فقط شخص خود را پردازش می‌کند
            if (uid != AppConfig.Uid) return;

            // 2) گرفتن یک عکس فوری محلی برای جلوگیری از پاک شدن توسط نخ دیگر
            var form = FormManager.skillDiary;
            if (form == null || form.IsDisposed || !form.IsHandleCreated) return;

            var (shouldWrite, count, totalDamage, critCount, luckyCount) =
                SkillDiaryGate.Register(uid, skillId, damage, iscrit, isLucky, treat); // ★ انتقال treat

            if (!shouldWrite || count <= 0) return;

            var duration = StatisticData._manager.GetFormattedCombatDuration();
            if (FormManager.showTotal) duration = FullRecord.GetEffectiveDurationString();

            var name = EmbeddedSkillConfig.GetLocalizedSkillDefinition(skillId.ToString()).Name;

            string line;
            if (count > 1)
            {
                // چند مرحله‌ای
                var parts = new List<string>
            {
                $"{name}",
                $"{(treat ? "درمان" : "آسیب")}:{totalDamage}",
                $"تعداد اجرای مهارت:{count}"
            };
                if (critCount > 0) parts.Add($"ضربه بحرانی:{critCount}");
                if (luckyCount > 0) parts.Add($"خوش‌شانسی:{luckyCount}");

                line = $"[{duration}] " + string.Join(" | ", parts);
            }
            else
            {
                // تک مرحله
                var parts = new List<string>
                {
                    $"{name}",
                    $"{(treat ? "درمان" : "آسیب")}:{damage}"
                };
                if (iscrit) parts.Add("ضربه بحرانی");
                if (isLucky) parts.Add("خوش‌شانسی");

                line = $"[{duration}] " + string.Join(" | ", parts);
            }



            FormManager.skillDiary.AppendDiaryLine(line);
        }



        /// <summary>
        /// پاکسازی منظم: نوشتن مراحل "فراتر از WindowMs بدون ادامه" (برای جلوگیری از انتظار همیشگی برای ضربه بعدی).
        /// پیشنهاد می‌شود در تایمر ۱ ثانیه‌ای شما فراخوانی شود.
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
                        // توجه: Start/Last بازنشانی نمی‌شوند، این مورد در Register بعدی دوباره استفاده می‌شود
                        yield return (kv.Key.Uid, kv.Key.SkillId, outCount, outDmg);
                    }
                }
            }
        }
        /// <summary>
        /// فراخوانی هنگام پاکسازی/پایان نبرد: نوشتن یکجا تمام مراحل موجود در پنجره (سپس توسط فراخواننده در دفترچه ثبت شود).
        /// پس از بازگشت، این مراحل صفر می‌شوند اما موارد دیکشنری حذف نمی‌شوند؛ برای پاکسازی کامل، دوباره Reset() را فراخوانی کنید.
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
        /// پاکسازی کامل حافظه داخلی (مراحل ثبت نشده دور ریخته می‌شوند).
        /// معمولاً پس از DrainAllPending() و تخلیه، Reset() فراخوانی می‌شود.
        /// </summary>
        public static void Reset() => _pending.Clear();


    }
}

    