using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace GetOffMyLawnBot.Helpers
{
    public static class Settings
    {
        public static readonly string Version = "0.0.1";
        public static readonly string Path = "config.json";

        private static JObject Config;
        

        #region Публичные свойства

        public static string StepCooldown
        {
            get
            {
                return Read("STEP-COOLDOWN");
            }
        }

        public static string SupportedVersion
        {
            get
            {
                return Read("SUPPORTED-APP-VERSION");
            }
        }

        #endregion

        #region Конструктор

        static Settings()
        {

            if (!File.Exists(Path))
            {
                InitConfig();
            }

            JObjectInit();

        }
        
        public static void InitConfig()
        {
            Config = new JObject();
            Write("CONFIG-CREATE-TIME", DateTime.Now.ToString(), true);
            Write("SUPPORTED-APP-VERSION", Version, true);
        }

        #endregion

        #region Методы работы с JSON

        public static void Write(string key, string value, bool itsNewConfig = false)
        {
            if (!itsNewConfig)
                JObjectInit();

            Config[key] = value;
            File.WriteAllText(Path, value, Encoding.GetEncoding(1251));
        }

        public static string Read(string key)
        {
            JObjectInit();
            try
            {
                if (Config[key] != null)
                    return Config[key].ToString();
                else
                    return "0";

            }
            catch
            {
                return string.Empty;
            }
        }

        private static void JObjectInit() => Config = JObject.Parse(File.ReadAllText(Path, Encoding.GetEncoding(1251)));

        #endregion
    }
}
