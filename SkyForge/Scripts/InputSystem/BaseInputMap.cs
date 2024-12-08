/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.InputSystem;
using System;

namespace SkyForge.Input
{
    public abstract class BaseInputMap : IInput
    {
        public TInputMap As<TInputMap>() where TInputMap : BaseInputMap
        {
            return this as TInputMap;
        }

        public abstract void Enable();
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
    }
}