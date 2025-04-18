/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;
using System.Linq;
using System;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceViewModel : IConsoleServiceViewModel
    {
        private const char PREFIX_COMMAND = '/';
        public ReactiveProperty<bool> IsShowConsole { get; private set; } = new ();
        
        public ReactiveProperty<Message> MessageProperty { get; private set; } = new();

        private List<IConsoleCommand> m_commands;

        private DIContainer m_container;
        private IConsoleInput m_inputConsole;

        public ConsoleServiceViewModel(DIContainer container, IConsoleInput inputConsole)
        {
            m_container = container;
            m_inputConsole = inputConsole;
            
            IsShowConsole.Value = false;
            MessageProperty.Value = Message.Empty();
            m_commands = new List<IConsoleCommand>();
            
            var assembly = SkyForgeDefineAssembly.GetPlayerAssembly();
            var classTypes = assembly.GetTypes().Where(type => type.IsClass && !type.IsAbstract && typeof(IConsoleCommand).IsAssignableFrom(type));
            
            foreach (var classType in classTypes)
            {
                var instanceCommand = Activator.CreateInstance(classType) as IConsoleCommand;
                m_commands.Add(instanceCommand);
            }
            
            Application.logMessageReceived += HandleLog;
        }

        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            if(m_inputConsole.IsOpenOrCloseConsole())
                IsShowConsole.Value = !IsShowConsole.Value;
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }
        
        [ReactiveMethod]
        public void ProcessCommand(object sender, string commandMessage)
        {
            if (commandMessage.Contains(PREFIX_COMMAND))
            {
                SeparateCommand(commandMessage, out string commandName, out string[] commandParams);
                
                foreach (var command in m_commands)
                {
                    if (command.CommandName.Equals(commandName))
                        command.Process(m_container, commandParams);
                }
            }
            else
            {
                LogMessage(commandMessage);
            }
        }
        
        public void LogMessage(string messageText)
        {
            var message = new Message(messageText, MessageType.Message);
            MessageProperty.Value = message;
        }

        public void LogWarning(string warrningText)
        {
            var message = new Message(warrningText, MessageType.Warning);
            MessageProperty.Value = message;
        }

        public void LogError(string errorText)
        {
            var message = new Message(errorText, MessageType.Error);
            MessageProperty.Value = message;
        }
        
        private void SeparateCommand(string commandMessage, out string commandName, out string[] commandParams)
        {
            var commandParts = commandMessage.Split(' ');
            commandName = string.Join("", commandParts[0].Skip(1).ToArray());
            commandParams = commandParts.Skip(1).ToArray();
        }

        private void HandleLog(string message, string stackTrace, LogType logType)
        {
            switch (logType)
            {
                case LogType.Error:
                    LogError(message);
                    break;
                case LogType.Warning:
                    LogWarning(message);
                    break;
                case LogType.Log:
                    LogMessage(message);
                    break;
                default:
                    LogMessage(message);
                    break;
            }
        }
    }
}
