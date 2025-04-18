/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceInput : BaseInput, IConsoleInput
    {
        public ConsoleServiceInput(IInputMap inputMap) : base(inputMap)
        {
            
        }

        public bool IsOpenOrCloseConsole()
        {
            var consoleInput = m_inputMap.As<ConsoleServiceInputMap>();
            return consoleInput.IsOpenOrCloseConsole();
        }
    }
}
