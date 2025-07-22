/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleService : IConsoleService
    {
        private const char PREFIX_COMMAND = '/';
        
        public event Action<Message> SendMessage;

        private List<IConsoleCommand> m_commands;
        
        private DIContainer m_container;

        public ConsoleService(DIContainer container)
        {
            m_container = container;
            
            m_commands = new List<IConsoleCommand>();
            
            var assembly = SkyForgeDefineAssembly.GetPlayerAssembly();
            
            if (assembly != null)
            {
                var classTypes = assembly.GetTypes().Where(type => type.IsClass && !type.IsAbstract && typeof(IConsoleCommand).IsAssignableFrom(type));

                foreach (var classType in classTypes)
                {
                    var instanceCommand = Activator.CreateInstance(classType) as IConsoleCommand;
                    m_commands.Add(instanceCommand);
                }
            }
            else
            {
                Debug.Log("Console service no assembly found");
            }
        }
        
        public void Dispose()
        {
            
        }
        
        public void ProcessCommand(object sender, string commandMessage)
        {
            if (commandMessage.Contains(PREFIX_COMMAND))
            {
                SeparateCommand(commandMessage, out string commandName, out string[] commandParams);
                
                foreach (var command in m_commands)
                {
                    if (command.CommandName.Equals(commandName))
                    {
                        command.Process(m_container, commandParams);
                        return;
                    }
                }
                
                LogError("unknown command: " + commandName);
            }
            else
            {
                LogMessage(commandMessage);
            }
        }

        public void LogMessage(string messageText)
        {
            var message = new Message(messageText, MessageType.Message);
            SendMessage?.Invoke(message);
        }

        public void LogWarning(string warningText)
        {
            var message = new Message(warningText, MessageType.Warning);
            SendMessage?.Invoke(message);
        }

        public void LogError(string errorText)
        {
            var message = new Message(errorText, MessageType.Error);
            SendMessage?.Invoke(message);
        }
        
        private void SeparateCommand(string commandMessage, out string commandName, out string[] commandParams)
        {
           var commandParts = commandMessage.Split(' ');
            commandName = string.Join("", commandParts[0].Skip(1).ToArray());
            commandParams = commandParts.Skip(1).ToArray();
        }
    }
}
