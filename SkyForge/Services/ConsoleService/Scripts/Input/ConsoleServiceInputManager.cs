/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using System.Linq;

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
            return GetInputs<IConsoleInput>().First();
        }
    }
}
