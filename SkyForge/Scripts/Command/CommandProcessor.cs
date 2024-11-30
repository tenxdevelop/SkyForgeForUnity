/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System;

namespace SkyForge.Command
{
    public class CommandProcessor : ICommandProcessor
    {
        private Dictionary<Type, object> m_commandHandlersMap = new ();

        public CommandProcessor() 
        { 
            
        }

        public void Dispose()
        {
            
        }

        public bool Process<TCommand>(TCommand command) where TCommand : ICommand
        {
            var typeCommand = typeof(TCommand);
            if (m_commandHandlersMap.TryGetValue(typeCommand, out var objectHandler))
            {
                var commandHandler = objectHandler as ICommandHandler<TCommand>;
                var result = commandHandler.Handle(command);
                return result;
            }
            return false;
        }

        public void RegisterCommandHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            var typeCommand = typeof(TCommand);
            if (m_commandHandlersMap.ContainsKey(typeCommand))
            {
                UnityEngine.Debug.LogError($"Error command: {typeCommand.Name}, contains in CommandProcessor");
                return;
            }
            m_commandHandlersMap[typeCommand] = handler;
        }
    }
}
