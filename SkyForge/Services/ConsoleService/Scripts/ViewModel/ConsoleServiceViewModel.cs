/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceViewModel : IConsoleServiceViewModel
    {
        public ReactiveProperty<bool> IsShowConsole { get; private set; } = new();
        
        public ReactiveProperty<Message> MessageProperty { get; private set; } = new();
        
        private IConsoleService m_consoleService;
        private IConsoleInput m_inputConsole;

        public ConsoleServiceViewModel(IConsoleService consoleService, IConsoleInput inputConsole)
        {
            m_consoleService = consoleService;
            m_inputConsole = inputConsole;
            
            IsShowConsole.Value = false;
            MessageProperty.Value = Message.Empty();
            Debug.Log("test");
            m_consoleService.SendMessage += HandleLog;
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
            m_consoleService.ProcessCommand(sender, commandMessage);
            
        }
        
        private void HandleLog(Message message)
        {
            MessageProperty.Value = message;
        }

        private void HandleLog(string message, string stackTrace, LogType logType)
        {
            switch (logType)
            {
                case LogType.Error:
                    m_consoleService.LogError(message);
                    break;
                case LogType.Warning:
                    m_consoleService.LogWarning(message);
                    break;
                case LogType.Log:
                    m_consoleService.LogMessage(message);
                    break;
                default:
                    m_consoleService.LogMessage(message);
                    break;
            }
        }
    }
}
