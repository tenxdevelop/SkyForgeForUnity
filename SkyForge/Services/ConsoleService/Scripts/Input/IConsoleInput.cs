/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using System;

namespace SkyForge.Services.ConsoleService
{
    public interface IConsoleInput : IInput
    {
        event Action IsOpenOrCloseConsoleEvent;
        bool IsOpenOrCloseConsole();
    }
}
