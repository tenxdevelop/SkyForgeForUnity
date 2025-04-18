/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceInputMap : BaseInputMap<ConsoleInput>
    {

        public bool IsOpenOrCloseConsole()
        {
            return OriginInputMap.ConsoleService.OpenConsole.triggered;
        }
        
    }
}
