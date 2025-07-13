/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using Unity.Netcode;
using UnityEngine;

namespace SkyForge.MVVM.NetworkBinders
{
#if UNITY_EDITOR
    [ExecuteInEditMode]
#endif
    public abstract class NetworkBinder : NetworkBehaviour
    {
        [SerializeField, HideInInspector] private string m_viewModelTypeFullName;
        [SerializeField, HideInInspector] private string m_propertyName;
        
        public string ViewModelTypeFullName => m_viewModelTypeFullName;
        protected string PropertyName => m_propertyName;
        
        private IBinding m_binding;
        
        protected virtual void OnDestroyed() { }
        protected virtual void OnStart() { }
        
        public void Bind(INetworkViewModel viewModel)
        {
            m_binding = BindInternal(viewModel);
            m_binding?.Binded();
        }
        
        protected abstract IBinding BindInternal(INetworkViewModel viewModel);
        
        private void Start()
        {
#if UNITY_EDITOR
            var parentView = GetComponentInParent<BaseNetworkView>();
            parentView.RegisterNetworkBinder(this);
#endif
            OnStart();
        }
        
        private void OnDestroy()
        {
#if UNITY_EDITOR
            var parentView = GetComponentInParent<BaseNetworkView>();
            if (parentView)
            {
                parentView.RemoveNetworkBinder(this);
            }
#endif
            m_binding?.Dispose();

            OnDestroyed();
        }
    }
}
