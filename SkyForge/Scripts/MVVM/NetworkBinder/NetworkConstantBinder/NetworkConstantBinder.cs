/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.Events;
using SkyForge.Reactive;
using UnityEngine;
using System;

namespace SkyForge.MVVM.NetworkBinders
{
    public abstract class NetworkConstantBinder : NetworkBinder
    {
        public abstract Type ArgumentType { get; }
    }
    
    public abstract class NetworkConstantBinder<T> : NetworkConstantBinder
    {
        public override Type ArgumentType => typeof(T);
        
        [SerializeField] private UnityEvent<T> m_bindConstantEvent;
        protected override IBinding BindInternal(INetworkViewModel networkViewModel)
        {
            var propertyInfo = networkViewModel.GetType().GetProperty(PropertyName);
            var constantProperty = propertyInfo.GetValue(networkViewModel) as IConstantProperty<T>;
            m_bindConstantEvent?.Invoke(constantProperty.Value);
            return null;
        }
    }
}