using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SkySea
{
    public class LanguageManager
    {
        private Dictionary<string, string> translations = new Dictionary<string, string>();
        private static LanguageManager instance;

        private LanguageManager()
        {
        }

        public static LanguageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LanguageManager();
                }
                return instance;
            }
        }

        public void LoadLanguage(string language)
        {
            string filePath = $"Resources\\{language}.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
        }

        public string GetString(string key)
        {
            return translations.ContainsKey(key) ? translations[key] : key;
        }
    }
}