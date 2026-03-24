/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.InputSystem;
using SkyForge.Input;
using System;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleInputMapper : BaseInputMapper<ConsoleNewInputSystem>
    {
        public event Action IsOpenOrCloseConsoleEvent;

        public ConsoleInputMapper()
        {
            OriginInput.ConsoleService.OpenConsole.performed += OnOpenConsolePerformed;
        }
        
        public override void Dispose()
        {
            OriginInput.ConsoleService.OpenConsole.performed -= OnOpenConsolePerformed;
        }
        
        public bool IsOpenOrCloseConsole()
        {
            return OriginInput.ConsoleService.OpenConsole.triggered;
        }

        private void OnOpenConsolePerformed(InputAction.CallbackContext context)
        {
            IsOpenOrCloseConsoleEvent?.Invoke();
        }
    }
}
