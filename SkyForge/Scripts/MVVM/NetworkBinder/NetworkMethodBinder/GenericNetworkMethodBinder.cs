/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using UnityEngine;
using System;

namespace SkyForge.MVVM.NetworkBinders
{
    public abstract class GenericNetworkMethodBinder : NetworkMethodBinder
    {
        public abstract Type ArgumentType { get; }
    }
    
    public class GenericNetworkMethodBinder<T> : GenericNetworkMethodBinder
    {
        public override Type ArgumentType => typeof(T);
        
        protected Action<object, T> m_action;
        protected override IBinding BindInternal(INetworkViewModel viewModel)
        {
            m_action = Delegate.CreateDelegate(typeof(Action<object, T>), viewModel, MethodName) as Action<object, T>;
            OnBind();
            return null;
        }
        protected virtual void OnBind() { }
        
        public void Perform(T newValue)
        {
            m_action?.Invoke(null, newValue);
        }

        public void Perform(Component sender, T newValue)
        {
            m_action?.Invoke(sender, newValue);
        }
    }
}