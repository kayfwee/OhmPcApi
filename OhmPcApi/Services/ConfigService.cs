using OhmPcApi.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmPcApi.Services
{
    /// <summary>
    /// Used to store and retrieve the global configuration during runtime
    /// </summary>
    public static class ConfigService
    {
        private const string CONFIG_FILE = "config.cfg";

        private static GlobalConfig config;
        public static GlobalConfig Config
        {
            get
            {
                if (config == null) InitialiseConfig();
                return config;
            }
            set
            {
                config = value;
                SaveConfigToFile();
            }
        }

        public static void InitialiseConfig()
        {
            var newConfig = new GlobalConfig();
            if (!File.Exists(CONFIG_FILE))
            {
                LogService.Log("Config file not found, creating a fresh one.");
            }
            else
            {
                LogService.Log("Reading config file...");
                using (StreamReader reader = new StreamReader(CONFIG_FILE))
                {
                    var configProperties = newConfig.GetType().GetProperties();
                    string line;
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        // Config file expected format: Property=Value
                        var lineValues = line.Split('=');
                        if (configProperties.Any(x => x.Name == lineValues[0]))
                        {
                            var configProperty = configProperties.FirstOrDefault(x => x.Name == lineValues[0]);
                            object propertyValue = null;

                            if (configProperty.PropertyType == typeof(bool))
                            {
                                bool boolValue;
                                if (!bool.TryParse(lineValues[1], out boolValue))
                                {
                                    boolValue = false;
                                }
                                propertyValue = boolValue;
                            }
                            else if (configProperty.PropertyType == typeof(string))
                            {
                                propertyValue = lineValues[1];
                            }

                            LogService.Log("Setting parameter [" + configProperty.Name + "] to [" + propertyValue.ToString() + "]");
                            configProperty.SetValue(newConfig, propertyValue);
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            config = newConfig;
            SaveConfigToFile();
        }

        public static void SaveConfigToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(CONFIG_FILE, false))
                {
                    foreach (var property in config.GetType().GetProperties())
                    {
                        writer.WriteLine(property.Name + "=" + property.GetValue(config));
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.Log("Failed to save config file.");
                LogService.Log(ex);
            }
        }
    }
}
