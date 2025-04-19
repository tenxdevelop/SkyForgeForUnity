/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.MigrationGameState
{
    public interface IMigrationStep
    {
        int FromVersion { get; }
        int ToVersion { get; }
        
        GameStateBase Migrate(GameStateBase oldState);
        
    }
}