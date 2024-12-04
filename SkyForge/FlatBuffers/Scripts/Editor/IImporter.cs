/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Threading.Tasks;

namespace SkyForge.FlatBuffers
{
    public interface IImporter<TMainSettings, TSettings> where TMainSettings : struct
    {
        string SheetName { get; }
        IFlatBufferPacker<TMainSettings, TSettings> FlatBufferPacker { get; }
        IImportConstants ImportConstants { get; }
        Task DownloadAndParse();
        void AddToSettings(TSettings settings);
        void SaveToFile();
        void LoadFromFile();
    }
}
