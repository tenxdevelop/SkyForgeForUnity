/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SkyForge.MigrationGameState
{
    public class GameStateMigrator : IGameStateMigrator
    {
        private List<IMigrationStep> m_steps;
        private List<IParseState> m_parsers;

        public GameStateMigrator()
        {
            m_steps = new List<IMigrationStep>();
            m_parsers = new List<IParseState>();
        }
        
        public void RegisterMigrationStep(IMigrationStep migrationStep)
        {
            m_steps.Add(migrationStep);
        }

        public void RegisterParser(IParseState parser)
        {
            m_parsers.Add(parser);
        }

        public T Migrate<T>(GameStateBase oldState) where T : GameStateBase
        {
            var dataResult = oldState;
            var version = oldState.Version;

            while (true)
            {
                var step = m_steps.FirstOrDefault(step => step.FromVersion.Equals(version));
                
                if (step is null)
                    break;
                
                dataResult = step.Migrate(dataResult);
                version = step.ToVersion;
            }
            
            return (T)dataResult;
        }

        public GameStateBase ParseState(string rawJson, int gameStateVersion)
        {
            foreach (var parser in m_parsers)
            {
                if(parser.Version.Equals(gameStateVersion))
                    return parser.ParseState(rawJson);
            }
            
            Debug.Log("Error: Unsupported Game State Version: " + gameStateVersion);
            return null;
        }
    }
}