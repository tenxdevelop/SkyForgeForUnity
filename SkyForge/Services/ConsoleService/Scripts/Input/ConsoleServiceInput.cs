/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using System;
using UnityEngine;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceInput : BaseInput, IConsoleInput
    {
        public event Action IsOpenOrCloseConsoleEvent;
        
        public ConsoleServiceInput(IInputMapper inputMapper) : base(inputMapper)
        {
            var consoleInputMapper = inputMapper.As<ConsoleInputMapper>();
            consoleInputMapper.IsOpenOrCloseConsoleEvent += OnIsOpenOrCloseConsoleEvent;
        }

        public void Dispose()
        {
            var consoleInputMapper = InputMapper.As<ConsoleInputMapper>();
            consoleInputMapper.IsOpenOrCloseConsoleEvent -= OnIsOpenOrCloseConsoleEvent;
        }
        
        public bool IsOpenOrCloseConsole()
        {
            var consoleInput = InputMapper.As<ConsoleInputMapper>();
            return consoleInput.IsOpenOrCloseConsole();
        }

        public void OnIsOpenOrCloseConsoleEvent()
        {
            IsOpenOrCloseConsoleEvent?.Invoke();
        }
    }
}
