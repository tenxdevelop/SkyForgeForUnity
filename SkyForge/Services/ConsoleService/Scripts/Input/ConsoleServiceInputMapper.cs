/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Input;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceInputMapper : BaseInputMapper<ConsoleNewInputSystem>
    {
        public override void Dispose()
        {
            
        }
        
        public bool IsOpenOrCloseConsole()
        {
            return OriginInput.ConsoleService.OpenConsole.triggered;
        }
    }
}
