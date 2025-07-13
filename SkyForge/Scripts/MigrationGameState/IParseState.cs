/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.MigrationGameState
{
    public interface IParseState
    {
        int Version { get; }
        
        GameStateBase ParseState(string rawJson);
    }
}