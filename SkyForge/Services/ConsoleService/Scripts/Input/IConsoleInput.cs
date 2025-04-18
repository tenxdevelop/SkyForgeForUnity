/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;

namespace SkyForge.Services.ConsoleService
{
    public interface IConsoleInput : IInput
    {
        bool IsOpenOrCloseConsole();
    }
}
