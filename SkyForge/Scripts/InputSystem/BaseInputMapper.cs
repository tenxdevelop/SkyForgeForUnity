/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.InputSystem;
using System;

namespace SkyForge.Input
{
    public abstract class BaseInputMapper : IInputMapper
    {
        public TInputMap As<TInputMap>() where TInputMap : BaseInputMapper
        {
            return this as TInputMap;
        }
        
        public abstract void Dispose();
        public abstract void Enable();
        
        public abstract void Disable();
    }

    public abstract class BaseInputMapper<TOriginInput> : BaseInputMapper where TOriginInput : IInputActionCollection2
    {
        protected TOriginInput OriginInput { get; }

        protected BaseInputMapper()
        {
            OriginInput = Activator.CreateInstance<TOriginInput>();
        }
        
        public override void Enable()
        {
            OriginInput.Enable();
        }

        public override void Disable()
        {
            OriginInput.Disable();
        }
    }
}
