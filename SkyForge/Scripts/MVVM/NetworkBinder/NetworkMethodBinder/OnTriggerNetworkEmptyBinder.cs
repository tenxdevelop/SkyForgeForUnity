/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace SkyForge.MVVM.NetworkBinders
{
    public abstract class OnTriggerNetworkEmptyBinder : EmptyNetworkMethodBinder
    {
        [SerializeField, HideInInspector] private string m_triggerViewTypeFullName;
        protected Type m_triggerViewType;

        private void Awake()
        {
            OnAwake();
        }
        protected virtual void OnAwake() { }
        protected override void OnBind()
        {
            m_triggerViewType = Type.GetType(m_triggerViewTypeFullName);
        }
    }
}