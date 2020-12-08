// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.Config;
using NetExtender.Config.Common;
using NetExtender.Localizations;

namespace EgeCreator.Model.Options
{
    public static class Settings
    {
        private static readonly Config Config;

        private const String SettingsSection = "Settings";
        private const String LanguageCodeKey = "Language code";
        
        public static IConfigProperty<Int32> LanguageCode { get; }
        
        static Settings()
        {
            Localization.LanguageChanged += () =>
            {
                LanguageCode.SetValue(Localization.CurrentCulture.LCID16);
                SaveProperties();
            };

            Config = Config.Create(ConfigType.JSON);

            LanguageCode = Config.GetProperty(LanguageCodeKey, Localization.BasicCulture.LCID, SettingsSection);

            SaveProperties();
        }

        public static void SaveProperties()
        {
            Config.SaveProperties();
        }
    }
}