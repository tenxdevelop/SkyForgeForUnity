/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Input
{
    public interface IInputMap
    {
        TInputMap As<TInputMap>() where TInputMap : BaseInputMap;
        void Enable();
        
        void Disable();
    }
}
