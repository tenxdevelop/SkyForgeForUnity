/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceViewModel : ViewModel, IConsoleServiceViewModel
    {
        public ReactiveProperty<bool> IsShowConsole { get; private set; } = new();
        public ReactiveProperty<Message> MessageProperty { get; private set; } = new();
        
        private readonly IConsoleService m_consoleService;
        private readonly IConsoleInput m_inputConsole;

        public ConsoleServiceViewModel(IConsoleService consoleService, IConsoleInput inputConsole)
        {
            m_consoleService = consoleService;
            m_inputConsole = inputConsole;
            
            IsShowConsole.Value = false;
            MessageProperty.Value = Message.Empty();
            
            m_consoleService.SendMessage += HandleLog;
            Application.logMessageReceived += HandleLog;
            
            Debug.Log("test console service");

            m_inputConsole.IsOpenOrCloseConsoleEvent += OnChangeShowConsoleCommand;
        }
        
        [ReactiveMethod]
        public void ProcessCommand(object sender, string commandMessage)
        {
            m_consoleService.ProcessCommand(sender, commandMessage);
        }

        public override void Dispose()
        {
            m_inputConsole.IsOpenOrCloseConsoleEvent -= OnChangeShowConsoleCommand;
        }
        
        private void OnChangeShowConsoleCommand()
        {
            IsShowConsole.Opposed();
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
