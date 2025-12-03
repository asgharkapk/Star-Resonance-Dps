using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using BlueProto;
using StarResonanceDpsAnalysis.Plugin;
using StarResonanceDpsAnalysis.Plugin.DamageStatistics;
using ZstdNet;
using StarResonanceDpsAnalysis.Core.test;
using Google.Protobuf.Collections;
using StarResonanceDpsAnalysis.Core.Module;
using StarResonanceDpsAnalysis.Forms; // 数据库同步

namespace StarResonanceDpsAnalysis.Core
{
    /// <summary>
    /// 消息解析器
    /// 负责处理从游戏抓包获得的TCP数据，包括解压缩、Protobuf解析、数据同步、伤害统计等。
    /// </summary>
    public class MessageAnalyzer
    {
        /// <summary>
        /// 顶层消息类型处理器
        /// Key = 消息类型ID (低15位)
        /// Value = 对应的解析方法
        /// </summary>
        private static readonly Dictionary<int, Action<ByteReader, bool>> MessageHandlers = new()
        {
            { 2, ProcessNotifyMsg },   // 通知消息
            { 6, ProcessFrameDown }    // 帧下行消息
        };

        /// <summary>
        /// 主入口：处理一批TCP数据包
        /// </summary>
        public static void Process(byte[] packets)
        {
           
                var packetsReader = new ByteReader(packets);
                while (packetsReader.Remaining > 0)
                {
                    // 包头长度检查
                    if (!packetsReader.TryPeekUInt32BE(out uint packetSize)) break;
                    if (packetSize < 6) break;                           // 小于最小长度，不合法
                    if (packetSize > packetsReader.Remaining) break;     // 不完整，等待下个包

                    // 按长度截取出一个完整包
                    var packetReader = new ByteReader(packetsReader.ReadBytes((int)packetSize));
                    uint sizeAgain = packetReader.ReadUInt32BE();
                    if (sizeAgain != packetSize) continue; // 长度不一致，丢弃

                    // 读取消息类型
                    var packetType = packetReader.ReadUInt16BE();
                    var isZstdCompressed = (packetType & 0x8000) != 0; // 高位bit15表示是否压缩
                    var msgTypeId = packetType & 0x7FFF;                // 低15位是真实类型

                    // 分发到对应处理方法
                    if (!MessageHandlers.TryGetValue(msgTypeId, out var handler))
                    {
                        continue; // 未识别的类型，跳过
                    }
                    handler(packetReader, isZstdCompressed);
                }
        
        }

        /// <summary>
        /// 玩家属性类型定义
        /// 用于 SyncNearEntities 消息中的属性ID解析
        /// </summary>
        public enum AttrType
        {
            /// <summary>名称（玩家/单位名，字符串）</summary>
            AttrName = 0x01,                    // name
            AttrId = 0x0A, // 整数（实体/怪物 ID，可映射名字）
            /// <summary>职业 ID（职业枚举/配置映射用）</summary>
            AttrProfessionId = 0xDC,            // profession id

            /// <summary>战力（Fight Point/Combat Power，整数）</summary>
            AttrFightPoint = 0x272E,            // fight power

            /// <summary>等级（Level）</summary>
            AttrLevel = 0x2710,                 // level

            /// <summary>阶位/段位（Rank Level，具体含义按游戏定义）</summary>
            AttrRankLevel = 0x274C,             // rank level

            /// <summary>暴击率（单位由上游决定，常见万分比或千分比）</summary>
            AttrCri = 0x2B66,                   // crit rate

            /// <summary>幸运率（单位由上游决定，常见万分比或千分比）</summary>
            AttrLucky = 0x2B7A,                 // lucky rate

            /// <summary>当前生命值（HP）</summary>
            AttrHp = 0x2C2E,                    // hp

            /// <summary>最大生命值（Max HP）</summary>
            AttrMaxHp = 0x2C38,                 // max hp

            /// <summary>
            /// 元素标识位（元素相关的位标志/掩码，如冰/雷/火等；具体 bit 含义按配置表解析）
            /// </summary>
            AttrElementFlag = 0x646D6C,         // element flags (bitmask)

            /// <summary>
            /// 减抗/易伤等级（Reduction Level，表示受到某类减抗效果的等级）
            /// </summary>
            AttrReductionLevel = 0x64696D,      // reduction/vulnerability level

            /// <summary>
            /// 减抗/易伤效果 ID（用于区分来源或具体效果条目）
            /// </summary>
            AttrReduntionId = 0x6F6C65,         // reduction effect id

            /// <summary>
            /// 能量标识位（Energy Flag/Charge 状态，通常为位标志；具体定义以协议/配置为准）
            /// </summary>
            AttrEnergyFlag = 0x543CD3C6         // energy flags (bitmask)
        }

        /// <summary>
        /// 伤害来源类型（区分来自技能本体、投射物、Buff 点伤、跌落伤害等）
        /// </summary>
        public enum EDamageSource
        {
            /// <summary>技能本体造成的伤害（如近战/法术技能命中）</summary>
            EDamageSourceSkill = 0,

            /// <summary>子弹/投射物造成的伤害（如箭矢、飞弹）</summary>
            EDamageSourceBullet = 1,

            /// <summary>Buff/DoT/场效等周期性或效果触发的伤害</summary>
            EDamageSourceBuff = 2,

            /// <summary>跌落伤害</summary>
            EDamageSourceFall = 3,

            /// <summary>伪子弹/内部触发用的投射体（服务端逻辑用，非真实子弹）</summary>
            EDamageSourceFakeBullet = 4,

            /// <summary>其他未归类来源（保底枚举，便于兼容）</summary>
            EDamageSourceOther = 100
        }


        /// <summary>
        /// 伤害类型
        /// </summary>
        public enum EDamageProperty
        {
            General = 0,
            Fire = 1,
            Water = 2,
            Electricity = 3,
            Wood = 4,
            Wind = 5,
            Rock = 6,
            Light = 7,
            Dark = 8,
            Count = 9,
        }

        /// <summary>
        /// 元素枚举转简短标签（含 emoji 图标）。
        /// </summary>
        /// <param name="damageProperty">EDamageProperty 枚举值</param>
        /// <returns>对应的标签字符串</returns>
        public static string GetDamageElement(int damageProperty)
        {
            switch (damageProperty)
            {
                case (int)EDamageProperty.General:
                    return "⚔️物";
                case (int)EDamageProperty.Fire:
                    return "🔥火";
                case (int)EDamageProperty.Water:
                    return "❄️冰";
                case (int)EDamageProperty.Electricity:
                    return "⚡雷";
                case (int)EDamageProperty.Wood:
                    return "🍀森";
                case (int)EDamageProperty.Wind:
                    return "💨风";
                case (int)EDamageProperty.Rock:
                    return "⛰️岩";
                case (int)EDamageProperty.Light:
                    return "🌟光";
                case (int)EDamageProperty.Dark:
                    return "🌑暗";
                case (int)EDamageProperty.Count:
                    return "❓？"; // unknown/保留
                default:
                    return "⚔️物";
            }
        }


        /// <summary>
        /// Notify 消息内部方法表
        /// Key = methodId
        /// Value = 对应的处理方法
        /// </summary>
        private static readonly Dictionary<uint, Action<byte[]>> ProcessMethods = new()
        {
            { 0x00000006U, ProcessSyncNearEntities },        // 同步周边玩家实体
            { 0x00000015U, ProcessSyncContainerData },       // 同步自身完整容器数据
            { 0x00000016U, ProcessSyncContainerDirtyData },  // 同步自身部分更新（脏数据）
            { 0x0000002EU, ProcessSyncToMeDeltaInfo },       // 同步自己受到的增量伤害
            { 0x0000002DU, ProcessSyncNearDeltaInfo }        // 同步周边增量伤害
        };

        /// <summary>
        /// 处理 Notify 消息（带 serviceUuid 和 methodId 的 RPC）
        /// </summary>
        public static void ProcessNotifyMsg(ByteReader packet, bool isZstdCompressed)
        {
            var serviceUuid = packet.ReadUInt64BE(); // 服务UUID
            _ = packet.ReadUInt32BE(); // stubId (暂时不用)
            var methodId = packet.ReadUInt32BE(); // 方法ID
            if (serviceUuid != 0x0000000063335342UL) return; // 非战斗相关，忽略

            byte[] msgPayload = packet.ReadRemaining();
            if (isZstdCompressed) msgPayload = DecompressZstdIfNeeded(msgPayload);

            if (!ProcessMethods.TryGetValue(methodId, out var processMethod)) return;
            processMethod(msgPayload);
        }

        /// <summary>
        /// 处理 FrameDown 消息（嵌套内部数据包）
        /// </summary>
        public static void ProcessFrameDown(ByteReader reader, bool isZstdCompressed)
        {
            _ = reader.ReadUInt32BE(); // serverSequenceId
            if (reader.Remaining == 0) return;

            var nestedPacket = reader.ReadRemaining();
            if (isZstdCompressed) nestedPacket = DecompressZstdIfNeeded(nestedPacket);
            Process(nestedPacket); // 递归解析内部消息
        }

        #region Zstd 解压逻辑
        private static readonly uint ZSTD_MAGIC = 0xFD2FB528;
        private static readonly uint SKIPPABLE_MAGIC_MIN = 0x184D2A50;
        private static readonly uint SKIPPABLE_MAGIC_MAX = 0x184D2A5F;

        /// <summary>
        /// 如果数据包含Zstd帧则解压缩，否则原样返回
        /// </summary>
        private static byte[] DecompressZstdIfNeeded(byte[] buffer)
        {
            if (buffer == null || buffer.Length < 4) return Array.Empty<byte>();
            int off = 0;
            while (off + 4 <= buffer.Length)
            {
                uint magic = BitConverter.ToUInt32(buffer, off);
                if (magic == ZSTD_MAGIC) break;
                if (magic >= SKIPPABLE_MAGIC_MIN && magic <= SKIPPABLE_MAGIC_MAX)
                {
                    if (off + 8 > buffer.Length) throw new InvalidDataException("不完整的skippable帧头");
                    uint size = BitConverter.ToUInt32(buffer, off + 4);
                    if (off + 8 + size > buffer.Length) throw new InvalidDataException("不完整的skippable帧数据");
                    off += 8 + (int)size;
                    continue;
                }
                off++;
            }
            if (off + 4 > buffer.Length) return buffer;

            using var input = new MemoryStream(buffer, off, buffer.Length - off, writable: false);
            using var decoder = new DecompressionStream(input);
            using var output = new MemoryStream();

            const long MAX_OUT = 32L * 1024 * 1024; // 最大解压32MB
            var temp = new byte[8192];
            long total = 0;
            int read;
            while ((read = decoder.Read(temp, 0, temp.Length)) > 0)
            {
                total += read;
                if (total > MAX_OUT) throw new InvalidDataException("解压结果超过32MB限制");
                output.Write(temp, 0, read);
            }
            return output.ToArray();
        }
        #endregion
        /// <summary>
        /// 同步周边实体，玩家数据
        /// </summary>
        /// <param name="playerUid"></param>
        /// <param name="attrs"></param>
        public static void processPlayerAttrs(ulong playerUid,RepeatedField<Attr> attrs)
        {     
            bool updated = false;
            string name = "";
            foreach (var attr in attrs)
            {
                if (attr.Id == 0 || attr.RawData == null || attr.RawData.Length == 0) continue;
                var reader = new Google.Protobuf.CodedInputStream(attr.RawData.ToByteArray());

                switch (attr.Id)
                {
                    case (int)AttrType.AttrName:
                        StatisticData._manager.SetNickname(playerUid, reader.ReadString());
                        updated = true;
                        break;
                    case (int)AttrType.AttrProfessionId:
                        StatisticData._manager.SetProfession(playerUid, GetProfessionNameFromId(reader.ReadInt32()));
                        updated = true;
                        break;
                    case (int)AttrType.AttrFightPoint:
                        StatisticData._manager.SetCombatPower(playerUid, reader.ReadInt32());
                        updated = true;
                        break;
                    case (int)AttrType.AttrLevel:
                        StatisticData._manager.SetAttrKV(playerUid, "level", reader.ReadInt32());
                        break;
                    case (int)AttrType.AttrRankLevel:
                        StatisticData._manager.SetAttrKV(playerUid, "rank_level", reader.ReadInt32());
                        break;
                    case (int)AttrType.AttrCri:
                        StatisticData._manager.SetAttrKV(playerUid, "cri", reader.ReadInt32());
                        break;
                    case (int)AttrType.AttrLucky:
                        StatisticData._manager.SetAttrKV(playerUid, "lucky", reader.ReadInt32());
                        break;
                    case (int)AttrType.AttrHp:
                        StatisticData._manager.SetAttrKV(playerUid, "hp", reader.ReadInt32());
                        break;
                    case (int)AttrType.AttrMaxHp:
                        _ = reader.ReadInt32();

                        break;
                    case (int)AttrType.AttrElementFlag:
                        _ = reader.ReadInt32();

                        break;
                    case (int)AttrType.AttrEnergyFlag:
                        _ = reader.ReadInt32();

                        break;
                    case (int)AttrType.AttrReductionLevel:
                        _ = reader.ReadInt32();

                        break;
                    default:
                        break;
                }
            }

 
        }

        public static void processEnemyAttrs(ulong enemyUid, RepeatedField<Attr> attrs)
        {
            #region
            //foreach (var attr in attrs)
            //{
            //    if (attr.Id == 0 || attr.RawData == null)
            //        continue;
            //    var reader = new Google.Protobuf.CodedInputStream(attr.RawData.ToByteArray());

            //   // Console.WriteLine(@$"发现属性ID {attr.Id} 对应敌人E{enemyUid} 原始数据={Convert.ToBase64String(attr.RawData.ToByteArray())}");
            //    switch (attr.Id)
            //    {
            //        case (int)AttrType.AttrName:
            //            {
            //                // 怪物名直接是 string
            //                string enemyName = reader.ReadString();

            //                Console.WriteLine($"发现怪物名 {enemyName}，对应ID {enemyUid}");
            //                break;
            //            }
            //        case (int)AttrType.AttrId:
            //            {
            //                // 怪物模板 ID
            //                int templateId = reader.ReadInt32();
            //                string name = MonsterNameResolver.Instance.GetName(templateId);
            //                if(!string.IsNullOrEmpty(name))
            //                {
            //                    Console.WriteLine($"怪物名：{name}，对应模板ID {templateId}");
            //                }

            //                break;
            //            }
            //        case (int)AttrType.AttrHp:
            //            {
            //                var data = attr.RawData.ToByteArray();
            //                if (data.Length == 0)
            //                {
            //                    //Console.WriteLine($"怪物 {enemyUid} 的血量数据为空，跳过");
            //                    break;
            //                }
            //                int enemyHp = reader.ReadInt32();
                           
            //                //Console.WriteLine($"发现怪物当前血量 {enemyHp}，对应敌人ID {enemyUid}"); 
            //                break;
            //            }
            //        case (int)AttrType.AttrMaxHp:
            //            {
            //                int enemyMaxHp = reader.ReadInt32();

            //                Console.WriteLine($"发现怪物最大血量 {enemyMaxHp}，对应敌人ID {enemyUid}");
            //                break;
            //            }
            //        default:
            //            {
            //                // unknown属性静默，可选 debug
            //                // this.logger.Debug($"Found unknown attrId {attr.Id} for E{enemyUid} {Convert.ToBase64String(attr.RawData)}");
            //                break;
            //            }
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// 同步周边实体 怪物和玩家
        /// </summary>
        public static void ProcessSyncNearEntities(byte[] payloadBuffer)
        {
            #region
            var syncNearEntities = SyncNearEntities.Parser.ParseFrom(payloadBuffer);
            if (syncNearEntities.Appear == null || syncNearEntities.Appear.Count == 0) return;

            foreach (var entity in syncNearEntities.Appear)
            {
                if (entity.EntType != EEntityType.EntChar) continue;
                ulong playerUid = Shr16((ulong)entity.Uuid); // 提取UID
               
                if (playerUid == 0) continue;

          

                var attrCollection = entity.Attrs;
                if (attrCollection?.Attrs == null) continue;
                switch(entity.EntType)
                {
                    case EEntityType.EntMonster:
                        processEnemyAttrs(playerUid, attrCollection.Attrs);
                        break;
                    case EEntityType.EntChar:
                        processPlayerAttrs(playerUid, attrCollection.Attrs);
                        break;
                    default:
                        break;
                }
               
        
            }
            #endregion
        }



        /// <summary>
        /// 同步周边增量伤害（范围内其他角色的技能/伤害）
        /// </summary>
        public static void ProcessSyncNearDeltaInfo(byte[] payloadBuffer)
        {
            var syncNearDeltaInfo = SyncNearDeltaInfo.Parser.ParseFrom(payloadBuffer);
            if (syncNearDeltaInfo.DeltaInfos == null || syncNearDeltaInfo.DeltaInfos.Count == 0) return;
            foreach (var aoiSyncDelta in syncNearDeltaInfo.DeltaInfos) ProcessAoiSyncDelta(aoiSyncDelta);
        }


        /// <summary>
        /// 处理一条技能伤害/治疗记录
        /// </summary>
        public static void ProcessAoiSyncDelta(AoiSyncDelta delta)
        {
            if (delta == null) return;
            ulong targetUuidRaw = (ulong)delta.Uuid;
            if (targetUuidRaw == 0) return;
            bool isTargetPlayer = IsUuidPlayerRaw(targetUuidRaw);
            ulong targetUuid = Shr16(targetUuidRaw);
            var attrCollection = delta.Attrs;
            if (attrCollection?.Attrs != null)
            {
                if(isTargetPlayer)
                {
                    //玩家
                    processPlayerAttrs(targetUuidRaw, attrCollection.Attrs);
                }
                else
                {
                    //怪物
                    processEnemyAttrs(targetUuid, attrCollection.Attrs);
                }
            }



                // SkillEffects：本次增量包含的技能相关效果（伤害/治疗等）

                var skillEffect = delta.SkillEffects;
            if (skillEffect?.Damages == null || skillEffect.Damages.Count == 0) return;


            foreach (var d in skillEffect.Damages)
            {
                long skillId = d.OwnerId;
                if (skillId == 0) continue;

                ulong attackerRaw = (ulong)(d.TopSummonerId != 0 ? d.TopSummonerId : d.AttackerUuid);
                if (attackerRaw == 0) continue;
                bool isAttackerPlayer = IsUuidPlayerRaw(attackerRaw);
                ulong attackerUuid = Shr16(attackerRaw);

                // 检查是否缺少基本信息，如果缺少则尝试补充
                if (isAttackerPlayer && attackerUuid != 0)
                {
                    var info = StatisticData._manager.GetPlayerBasicInfo(attackerUuid);
                }

                // 伤害数值
                long damageSigned = d.HasValue ? d.Value : (d.HasLuckyValue ? d.LuckyValue : 0L);
                if (damageSigned == 0) continue;
                ulong damage = (ulong)(damageSigned < 0 ? -damageSigned : damageSigned);

                // 标志位
                bool isCrit = d.TypeFlag != null && ((d.TypeFlag & 1) == 1);
                bool isHeal = d.Type == EDamageType.Heal;
                var luckyValue = d.LuckyValue;
                bool isLucky = luckyValue != null && luckyValue != 0;
                ulong hpLessen = d.HasHpLessenValue ? (ulong)d.HpLessenValue : 0UL;

                // 1) 是否“造成”幸运（CauseLucky）：TypeFlag 的 bit2
                bool isCauseLucky = d.TypeFlag != null && ((d.TypeFlag & 0b100) == 0b100);

                // 2) 是否 Miss
                bool isMiss = d.HasIsMiss && d.IsMiss;

                // 3) 是否打死/目标死亡
                bool isDead = d.HasIsDead && d.IsDead;

                // 4) 元素标签（把 d.Property 转你现有的标签字符串）
                string damageElement = GetDamageElement((int)d.Property);

                // 5) 伤害来源（EDamageSource）
                int damageSource = (int)(d.HasDamageSource ? d.DamageSource : 0);


                // 打桩模式（只统计自己对特定目标的伤害）
                if (AppConfig.PilingMode)
                {
                    if (attackerUuid != AppConfig.Uid) continue;
                    if (targetUuid != 75) continue;
                }
                
                // 区分目标是否是玩家
                if (isTargetPlayer)
                {
                    if (isHeal)
                    {

                            StatisticData._manager.AddHealing(isAttackerPlayer?attackerUuid:0, (ulong)skillId, damageElement, hpLessen, isCrit, isLucky, isCauseLucky, targetUuid);
                        
                  
                       
                    }
                    else
                    {
                       
                        StatisticData._manager.AddTakenDamage(targetUuid, (ulong)skillId, damage, damageSource, isMiss, isDead, isCrit, isLucky, hpLessen);
                    }
                }
                else
                {
                    if (!isHeal && isAttackerPlayer)
                    {
                    
                        StatisticData._manager.AddDamage(attackerUuid, (ulong)skillId, damageElement, damage, isCrit, isLucky, isCauseLucky, hpLessen);
                    }
                    //if (AppConfig.NpcsTakeDamage)
                    //{
               
                    StatisticData._npcManager.AddNpcTakenDamage(targetUuid, attackerUuid, skillId, damage, isCrit, isLucky, hpLessen, isMiss, isDead);
                        
                        
                    //}
                }
            }
        }

        /// <summary>
        /// 当前用户UUID
        /// </summary>
        public static long currentUserUuid = 0;

        /// <summary>
        /// 同步自身增量伤害
        /// </summary>
        public static void ProcessSyncToMeDeltaInfo(byte[] payloadBuffer)
        {
            var syncToMeDeltaInfo = SyncToMeDeltaInfo.Parser.ParseFrom(payloadBuffer);
            var aoiSyncToMeDelta = syncToMeDeltaInfo.DeltaInfo;
            long uuid = aoiSyncToMeDelta.Uuid;
            if (uuid != 0 && currentUserUuid != uuid)
            {
                currentUserUuid = uuid;
            }
            var aoiSyncDelta = aoiSyncToMeDelta.BaseDelta;
            if (aoiSyncDelta == null) return;
            ProcessAoiSyncDelta(aoiSyncDelta);
        }


        public static byte[] PayloadBuffer = new byte[0];
        /// <summary>
        /// 同步自身完整容器数据（基础属性、昵称、职业、战力）
        /// </summary>
        public static void ProcessSyncContainerData(byte[] payloadBuffer)
        {
            if(FormManager.moduleCalculationForm != null&& !FormManager.moduleCalculationForm.IsDisposed)
            {
                PayloadBuffer = payloadBuffer;
                
            }
           
            //Console.WriteLine("Head (前64字节): " + ToHex(payloadBuffer));
            var syncContainerData = SyncContainerData.Parser.ParseFrom(payloadBuffer);
            if (syncContainerData?.VData == null) return;

            var vData = syncContainerData.VData;
            if (vData.CharId == null || vData.CharId == 0) return;

            ulong playerUid = (ulong)vData.CharId;
            AppConfig.Uid = playerUid;
            bool updated = false;

            if (vData.RoleLevel?.Level != 0)
                StatisticData._manager.SetAttrKV(playerUid, "level", vData.RoleLevel.Level);

            if (vData.Attr?.CurHp != 0)
                StatisticData._manager.SetAttrKV(playerUid, "hp", (int)vData.Attr.CurHp);

            if (vData.Attr?.MaxHp != 0)
                StatisticData._manager.SetAttrKV(playerUid, "max_hp", (int)vData.Attr.MaxHp);
       
            if (vData.CharBase != null)
            {
                if (!string.IsNullOrEmpty(vData.CharBase.Name))
                {
                    StatisticData._manager.SetNickname(playerUid, vData.CharBase.Name);
                    AppConfig.NickName = vData.CharBase.Name;
                    updated = true;
                }

                if (vData.CharBase.FightPoint != 0)
                {
                    StatisticData._manager.SetCombatPower(playerUid, vData.CharBase.FightPoint);
                    AppConfig.CombatPower = vData.CharBase.FightPoint;
                    updated = true;
                }

            }

            var professionList = vData.ProfessionList;
            if (professionList != null && professionList.CurProfessionId != 0)
            {
                var professionName = GetProfessionNameFromId(professionList.CurProfessionId);
                AppConfig.Profession = professionName;
                updated = true;
            }


        }


        /// <summary>
        /// 同步自身部分更新（脏数据） //增量更新，有数据就更新
        /// </summary>
        public static void ProcessSyncContainerDirtyData(byte[] payloadBuffer)
        {
            try
            {
                if (currentUserUuid == 0) return;
                var dirty = SyncContainerDirtyData.Parser.ParseFrom(payloadBuffer);
                if (dirty?.VData?.BufferS == null || dirty.VData.BufferS.Length == 0) return;

                var buf = dirty.VData.BufferS.ToByteArray();
                using var ms = new MemoryStream(buf, writable: false);
                using var br = new BinaryReader(ms);

                if (!DoesStreamHaveIdentifier(br)) return;

                uint fieldIndex = br.ReadUInt32();
                _ = br.ReadInt32();

                ulong playerUid = (ulong)currentUserUuid >> 16;
                bool updated = false;

                switch (fieldIndex)
                {
                    case 2: // 名字和战力
                        {
                            if (!DoesStreamHaveIdentifier(br)) break;
                            fieldIndex = br.ReadUInt32();
                            _ = br.ReadInt32();
                            switch (fieldIndex)
                            {
                                case 5: // 名字
                                    {
                                        string playerName = StreamReadString(br);
                                        if (!string.IsNullOrEmpty(playerName))
                                        {
                                            StatisticData._manager.SetNickname(playerUid, playerName);
                                            AppConfig.NickName = playerName;
                                            updated = true;
                                        }
                                        break;
                                    }
                                case 35: // 战力
                                    {
                                        uint fightPoint = br.ReadUInt32();
                                        _ = br.ReadInt32();
                                        if (fightPoint != 0)
                                        {
                                            StatisticData._manager.SetCombatPower(playerUid, (int)fightPoint);
                                            AppConfig.CombatPower = (int)fightPoint;
                                            updated = true;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case 16: // HP
                        {
                            if (!DoesStreamHaveIdentifier(br)) break;
                            fieldIndex = br.ReadUInt32();
                            _ = br.ReadInt32();
                            switch (fieldIndex)
                            {
                                case 1: // 当前血量
                                    {
                                        uint curHp = br.ReadUInt32();
                                        StatisticData._manager.SetAttrKV(playerUid, "hp", (int)curHp);
                                        break;
                                    }
                                case 2: // 最大血量
                                    {
                                        uint maxHp = br.ReadUInt32();
                                        StatisticData._manager.SetAttrKV(playerUid, "max_hp", (int)maxHp);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 61: // 职业
                        {
                            if (!DoesStreamHaveIdentifier(br)) break;
                            fieldIndex = br.ReadUInt32();
                            _ = br.ReadInt32();
                            if (fieldIndex == 1)
                            {
                                uint curProfessionId = br.ReadUInt32();
                                _ = br.ReadInt32();
                                if (curProfessionId != 0)
                                {
                                    var professionName = GetProfessionNameFromId((int)curProfessionId);
                                    AppConfig.Profession = professionName;
                                    StatisticData._manager.SetProfession(playerUid, professionName);
                                    updated = true;
                                }
                            }
                            break;
                        }
                }


            }
            catch { }
        }

        /// <summary>
        /// 判断数据流是否还有标识符
        /// </summary>
        private static bool DoesStreamHaveIdentifier(BinaryReader br)
        {
            var s = br.BaseStream;

            // 先保证至少能读前 8 字节（uint32 + int32）
            if (s.Position + 8 > s.Length) return false;

            uint id1 = br.ReadUInt32();  // 期望 0xFFFFFFFE
            int guard1 = br.ReadInt32(); // 跟随占位/长度（无论如何都消耗）

            if (id1 != 0xFFFFFFFE)
            {
                // 与 JS 一样：首段不对就返回 false（此时已前进 8 字节）
                return false;
            }

            // 通过第一段校验后，再读后续 8 字节
            if (s.Position + 8 > s.Length) return false;

            int id2 = br.ReadInt32();    // 理想情况下是 0xFFFFFFFD（即 -3）
            int guard2 = br.ReadInt32(); // 占位/保留

            // JS 代码并未强制校验 id2，所以这里直接返回 true
            return true;
        }


        /// <summary>
        /// 从流中读取字符串（带4字节对齐）
        /// </summary>
        private static string StreamReadString(BinaryReader br)
        {
            uint length = br.ReadUInt32();  // uint32LE
            _ = br.ReadInt32();             // guard（占位/长度，无论如何都消耗）

            // 即使 length 为 0，也要读后置 guard，和 JS 行为保持一致
            byte[] bytes = length > 0 ? br.ReadBytes((int)length) : Array.Empty<byte>();

            _ = br.ReadInt32();             // guard（占位/保留）

            return bytes.Length == 0 ? string.Empty : Encoding.UTF8.GetString(bytes);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsUuidPlayerRaw(ulong uuidRaw) => (uuidRaw & 0xFFFFUL) == 640UL; // UUID低16位标识玩家

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ulong Shr16(ulong v) => v >> 16; // 右移16位得到玩家UID

        /// <summary>
        /// 职业ID映射为职业名称
        /// </summary>
        public static string GetProfessionNameFromId(int professionId) => professionId switch
        {
            1 => Properties.Strings.Profession_Stormblade,
            2 => Properties.Strings.Profession_FrostMage,
            3 => Properties.Strings.Profession_PurifyingAxe,
            4 => Properties.Strings.Profession_WindKnight,
            5 => Properties.Strings.Profession_VerdantOracle,
            9 => Properties.Strings.Profession_HeavyGuardian,
            11 => Properties.Strings.Profession_Marksman,
            12 => Properties.Strings.Profession_AegisKnight,
            8 => Properties.Strings.Profession_ThunderHandCannon,
            10 => Properties.Strings.Profession_DarkSpiritDance,
            13 => Properties.Strings.Profession_SoulMusician,
            _ => string.Empty,
        };
    }
}
