/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM;

namespace SkyForge.Services.ConsoleService
{
    public interface IConsoleServiceViewModel : IViewModel
    {
        void ProcessCommand(object sender, string command);
        
        void LogMessage(string messageText);

        void LogWarning(string warningText);
        
        void LogError(string errorText);
    }
}
