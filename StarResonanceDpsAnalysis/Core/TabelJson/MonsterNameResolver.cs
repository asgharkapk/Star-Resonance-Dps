using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarResonanceDpsAnalysis.Core.TabelJson
{
    /// 怪物名字解析器：启动时从 monster_names.json 读取到内存，后续直接查字典。
    /// </summary>
    public class MonsterNameResolver
    {
        private readonly Dictionary<int, string> _id2Name = new();

        // 单例实例
        public static MonsterNameResolver Instance { get; private set; } = null!;

        // 构造函数 private，避免外部随便 new
        private MonsterNameResolver(string jsonPath)
        {
            if (File.Exists(jsonPath))
            {
                LoadFromJson(File.ReadAllText(jsonPath));
            }
            else
            {
                string fallbackPath = Path.Combine(AppContext.BaseDirectory, "Core", "TabelJson", "monster_names.json");
                if (!File.Exists(fallbackPath))
                    throw new FileNotFoundException("缺少 monster_names.json", fallbackPath);

                LoadFromJson(File.ReadAllText(fallbackPath));
            }
        }

        public static void Initialize(string jsonPath)
        {
            // 只初始化一次
            if (Instance == null)
                Instance = new MonsterNameResolver(jsonPath);
        }

        private void LoadFromJson(string json)
        {
            var doc = JsonDocument.Parse(json);
            foreach (var prop in doc.RootElement.EnumerateObject())
            {
                if (int.TryParse(prop.Name, out int id))
                {
                    string name = prop.Value.GetString() ?? "";
                    if (!string.IsNullOrWhiteSpace(name))
                        _id2Name[id] = name.Trim();
                }
            }
        }

        public string GetName(int id) =>
            _id2Name.TryGetValue(id, out var name) ? name : $"Unknown monster({id})";
    }

}
