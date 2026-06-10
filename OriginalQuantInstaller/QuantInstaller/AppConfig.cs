using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace BrukerAXS.QuantInstaller
{
    public static class AppConfig
    {
        public static Dictionary<string, string> ConfigSettings { get; } = new Dictionary<string, string>();

        public static void ReadAppConfig()
        {
            string configFileFullPath = $"{Environment.CurrentDirectory}\\AppConfig.xml";

            if (File.Exists(configFileFullPath))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                using (XmlReader xmlReader = XmlReader.Create(configFileFullPath, settings))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "ConfigItem")
                        {
                            string name = xmlReader.GetAttribute("Name");
                            string value = xmlReader.GetAttribute("Value");

                            ConfigSettings[name] = value;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"AppConfig.xml file not found.\nShould be located at {configFileFullPath} (same folder as the .exe to start this app).\nThe application will now close. Please check this location and if necessary, re-install this app and try again.", "Config File Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }


        }
    }
}
