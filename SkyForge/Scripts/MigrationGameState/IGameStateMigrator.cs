/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.MigrationGameState
{
    public interface IGameStateMigrator
    {
        void RegisterMigrationStep(IMigrationStep migrationStep);
        
        T Migrate<T>(GameStateBase oldState) where T : GameStateBase;

        GameStateBase ParseState(string rawJson, int gameStateVersion);
    }
}