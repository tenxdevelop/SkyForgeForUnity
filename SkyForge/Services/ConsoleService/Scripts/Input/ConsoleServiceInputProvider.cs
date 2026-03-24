/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;
using System.Linq;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceInputProvider : BaseInputProvider
    {
        public ConsoleServiceInputProvider() : base(new ConsoleInputMapper())
        {
            
        }
        
        public IConsoleInput GetConsoleInput()
        {
            return GetInputs<IConsoleInput>().First();
        }
    }
}
