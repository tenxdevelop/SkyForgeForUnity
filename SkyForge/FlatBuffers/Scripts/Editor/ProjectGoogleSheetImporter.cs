/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Extention.GoogleImporter;
using System.Threading.Tasks;
using System.IO;

namespace SkyForge.FlatBuffers
{
    public abstract class ProjectGoogleSheetImporter<TMainSettings, TSettings> : GoogleSheetsImporter where TMainSettings : struct
    {
        public string SheetName { get; private set; }

        public IFlatBufferPacker<TMainSettings, TSettings> FlatBufferPacker { get; private set; }

        public IImportConstants ImportConstants { get; private set; }

        public TSettings LocalSettings { get; protected set; }

        protected abstract string settingsFileName { get; }

        protected string localSettingsFilePath => Path.Combine(ImportConstants.GetSettingFolder(), settingsFileName);

        protected ProjectGoogleSheetImporter(IFlatBufferPacker<TMainSettings, TSettings> flatbufferPacker, IImportConstants importConstants, 
                                  string spreadSheetId, string sheetName) : base(spreadSheetId)
        {
            ImportConstants = importConstants;
            FlatBufferPacker = flatbufferPacker;
            SheetName = sheetName;

            CreateWithCredentials(this.ImportConstants.GetCredentialsPath());
        }

        public void SaveToFile()
        {
            SettingsFileUtils.SaveSettings(FlatBufferPacker, LocalSettings, ImportConstants.GetSettingFolder(), settingsFileName);
        }

        public void LoadFromFile()
        {
            LocalSettings = SettingsFileUtils.LoadSettings(FlatBufferPacker, localSettingsFilePath);
        }

        protected Task DownloadAndParceSheet()
        {
            return DownloadAndParseSheets(SheetName);
        }

    }
}
