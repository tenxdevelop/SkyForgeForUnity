/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;

namespace SkyForge.Infrastructure.FlatBuffers
{
    public interface IFlatBuffersScriptGenerated
    {
        IEnumerable<string> GetSchemaPaths();
        string GetOutputDirectory();
    }
}
