/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Services.ConsoleService
{
    public interface IConsoleCommand
    {
        string CommandName { get; }
        
        void Process(DIContainer container, string[] parameters);
        
    }
}
