/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.Events;
using UnityEngine;

namespace SkyForge.MVVM.NetworkBinders
{
    public class NetworkUnityEventBinder<T> : ObservableNetworkBinder<T>
    {
        [SerializeField] private UnityEvent<T> m_event;
        [SerializeField] private UnityEvent<object, T> m_eventWithAnalitics;
        
        protected override void OnPropertyChanged(object sender, T newValue)
        {
            if (IsServer)
            {
                m_event?.Invoke(newValue);
                m_eventWithAnalitics?.Invoke(sender, newValue);
            }
        }
    }
}