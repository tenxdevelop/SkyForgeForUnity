/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.InputSystem;
using System;

namespace SkyForge.Input
{
    public abstract class BaseInputMap : IInputMap
    {
        public TInputMap As<TInputMap>() where TInputMap : BaseInputMap
        {
            return this as TInputMap;
        }

        public abstract void Enable();
        
        public abstract void Disable();
    }

    public abstract class BaseInputMap<TOriginInputMap> : BaseInputMap where TOriginInputMap : IInputActionCollection2
    {
        public TOriginInputMap OriginInputMap { get; }

        public BaseInputMap()
        {
            OriginInputMap = Activator.CreateInstance<TOriginInputMap>();
        }

        public override void Enable()
        {
            OriginInputMap.Enable();
        }

        public override void Disable()
        {
            OriginInputMap.Disable();
        }
    }
}
