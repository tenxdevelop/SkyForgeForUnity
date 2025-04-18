/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceInputManager : BaseInputManager
    {
        public ConsoleServiceInputManager() : base(new ConsoleServiceInputMap())
        {
            
        }

        public override void Init()
        {
            
        }

        public IConsoleInput GetConsoleInput()
        {
            return GetInput<IConsoleInput>();
        }
        
        
        public override void Dispose()
        {
            m_inputMap.Disable();
        }
    }
}
