/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Services.ConsoleService
{
    public interface IConsoleService : IDisposable
    {
        event Action<Message> SendMessage;
        void ProcessCommand(object sender, string command);
        
        void LogMessage(string messageText);

        void LogWarning(string warningText);
        
        void LogError(string errorText);
    }
}
