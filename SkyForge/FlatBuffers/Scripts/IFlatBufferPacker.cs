using Google.FlatBuffers;

namespace SkyForge.FlatBuffers
{
    public interface IFlatBufferPacker<TMainSettings, TSettings> where TMainSettings : struct
    {
        Offset<TMainSettings> Pack(FlatBufferBuilder builder, TSettings settings);

        TMainSettings GetRootAsRootSettings(ByteBuffer buffer);

        TSettings UnPack(TMainSettings mainSettings);
    }
}
