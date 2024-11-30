/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM.Binders.Infrastructure;
using UnityEngine.Events;
using UnityEngine;

namespace SkyForge.MVVM.Binders
{
    public class IntToBoolUnityEventBinder : ObservableBinder<int>
    {
        [SerializeField] private CompareOperation m_compareOperation;
        [SerializeField] private int m_compareValue;
        [SerializeField] private UnityEvent<bool> m_event;
        [SerializeField] private UnityEvent<object, bool> m_eventWithAnalitics;
        
        protected override void OnPropertyChanged(object sender, int newValue)
        {
            var result = m_compareOperation.Compare(newValue, m_compareValue);
            m_event?.Invoke(result);
            m_eventWithAnalitics?.Invoke(sender, result);
        }
    }
}