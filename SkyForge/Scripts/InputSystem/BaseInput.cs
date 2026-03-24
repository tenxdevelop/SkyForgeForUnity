/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Input
{
    public abstract class BaseInput
    {
        protected readonly IInputMapper InputMapper;
        protected BaseInput(IInputMapper inputMapper)
        {
            InputMapper = inputMapper;
        }
    }
}
