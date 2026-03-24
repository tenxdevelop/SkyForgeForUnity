/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Input
{
    public interface IInputMapper : IDisposable
    {
        TInputMap As<TInputMap>() where TInputMap : BaseInputMapper;
        void Enable();
        void Disable();
    }
}
