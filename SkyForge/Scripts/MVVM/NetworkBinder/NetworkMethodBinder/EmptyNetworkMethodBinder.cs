/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using UnityEngine;
using System;

namespace SkyForge.MVVM.NetworkBinders
{
    public class EmptyNetworkMethodBinder : NetworkMethodBinder
    {
        [SerializeField] protected Action<object> m_action;
        protected override IBinding BindInternal(INetworkViewModel viewModel)
        {
            m_action = Delegate.CreateDelegate(typeof(Action<object>), viewModel, MethodName) as Action<object>;
            OnBind();
            
            return null;
        }
        
        public void Perform()
        {
            m_action?.Invoke(null);
        }

        public void Perform(Component sender)
        {
            m_action?.Invoke(sender);
        }
        
        protected virtual void OnBind() { }
    }
}