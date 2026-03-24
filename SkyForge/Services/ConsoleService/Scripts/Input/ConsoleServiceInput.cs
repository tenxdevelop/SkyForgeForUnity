/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceInput : BaseInput, IConsoleInput
    {
        public ConsoleServiceInput(IInputMapper inputMapper) : base(inputMapper)
        {
            
        }

        public bool IsOpenOrCloseConsole()
        {
            var consoleInput = InputMapper.As<ConsoleServiceInputMapper>();
            return consoleInput.IsOpenOrCloseConsole();
        }

        
    }
}
