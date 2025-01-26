/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using UnityEngine;
using System;

namespace SkyForge.FlatBuffers
{
    public static class SettingsImportUtils 
    {

        public static void ImportAllConfigs<TMainSettings, TSettings>() where TMainSettings : struct where TSettings : class
        {
            var allImporters = GetAllImporters<TMainSettings, TSettings>();

            ImportConfigs(allImporters);
        }

        public static async void ImportConfig<TMainSettings, TSettings>(IImporter<TMainSettings, TSettings> importer) where TMainSettings : struct where TSettings : class
        {
            var resultSettings = Activator.CreateInstance(typeof(TSettings)) as TSettings;
            var allImporters = GetAllImporters<TMainSettings, TSettings>();

            await Import(resultSettings, allImporters, importer);

            LoadOtherImporters(resultSettings, allImporters);

            SettingsFileUtils.SaveSettings(importer.FlatBufferPacker, resultSettings, importer.ImportConstants.GetResourcesFolder(), importer.ImportConstants.GetSettingsFileName());
            Debug.Log($"{importer.ImportConstants.GetSettingsFileName()} has been updated and saved");
        }


        public static async void ImportConfigs<TMainSettings, TSettings>(IEnumerable<IImporter<TMainSettings, TSettings>> importers) where TMainSettings : struct where TSettings : class
        {
            var resultSettings = Activator.CreateInstance(typeof(TSettings)) as TSettings;
            var allImporters = GetAllImporters<TMainSettings, TSettings>();

            var flatBufferPacker = importers.First().FlatBufferPacker;
            var importConstants = importers.First().ImportConstants;

            foreach (var importer in importers)
            {
                await Import(resultSettings, allImporters, importer);
            }

            LoadOtherImporters(resultSettings, allImporters);

            SettingsFileUtils.SaveSettings(flatBufferPacker, resultSettings, importConstants.GetResourcesFolder(), importConstants.GetSettingsFileName());
            Debug.Log($"{importConstants.GetSettingsFileName()} has been updated and saved");

        }

        private static async Task Import<TMainSettings, TSettings>(TSettings resultSettings, List<IImporter<TMainSettings, TSettings>> allImporters, 
                                                                   IImporter<TMainSettings, TSettings> importer) where TMainSettings : struct
        {
            allImporters.Remove(importer);

            await importer.DownloadAndParse();
            importer.SaveToFile();
            importer.AddToSettings(resultSettings);

            Debug.Log($"Local config has been updated and saved: {importer.SheetName}");
        }

        private static void LoadOtherImporters<TMainSettings, TSettings>(TSettings resultSettings, List<IImporter<TMainSettings, TSettings>> allImporters) where TMainSettings : struct
        {
            foreach (var otherImporter in allImporters)
            {
                otherImporter.LoadFromFile();
                otherImporter.AddToSettings(resultSettings);
            }
        }

        private static List<IImporter<TMainSettings, TSettings>> GetAllImporters<TMainSettings, TSettings>() where TMainSettings : struct
        {
            var allImporter = new List<IImporter<TMainSettings, TSettings>>();
            var playerAssembly = GetPlayerAssembly();
            var allImporterType = playerAssembly.GetTypes().Where(type => typeof(IImporter<TMainSettings, TSettings>).IsAssignableFrom(type));

            foreach (var importerType in allImporterType)
            {
                allImporter.Add(Activator.CreateInstance(importerType) as IImporter<TMainSettings, TSettings>);
            }

            return allImporter;
        }

        private static Assembly GetPlayerAssembly()
        {
            Assembly result = null;
            var allAsemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in allAsemblies)
            {
                if (assembly.FullName.Contains("Assembly-CSharp"))
                    result = assembly;
            }
            return result;
        }
    }
}

#endif
