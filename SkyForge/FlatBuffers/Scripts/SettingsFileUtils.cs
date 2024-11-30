/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using Google.FlatBuffers;
using UnityEditor;
using System.IO;

namespace SkyForge.Infrastructure.FlatBuffers
{
    public static class SettingsFileUtils
    {
        public static void SaveSettings<TMainSettings, TSettings>(IFlatBufferPacker<TMainSettings, TSettings> packer, TSettings settings, 
                                                                  string settingsFolder, string settingsFileName) where TMainSettings : struct
        {
            if (!Directory.Exists(settingsFolder))
            {
                Directory.CreateDirectory(settingsFolder);
            }

            var filePath = Path.Combine(settingsFolder, settingsFileName);
            var builder = new FlatBufferBuilder(1024);
            var offset = packer.Pack(builder, settings);
            builder.Finish(offset.Value);

            var data = builder.SizedByteArray();
            File.WriteAllBytes(filePath, data);

            AssetDatabase.Refresh();
        }

        public static TSettings LoadSettings<TMainSettings, TSettings>(IFlatBufferPacker<TMainSettings, TSettings> packer, string localSettingsFilePath) where TMainSettings : struct
        {
            if (File.Exists(localSettingsFilePath))
            {
                var data = File.ReadAllBytes(localSettingsFilePath);
                var byteBuffer = new ByteBuffer(data);
                var mainSettings = packer.GetRootAsRootSettings(byteBuffer);
                var settings = packer.UnPack(mainSettings);
                return settings;
            }

            return default(TSettings);
        }
    }
}
