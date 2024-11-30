/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM.Binders.Infrastructure;
using UnityEngine.Events;
using UnityEngine;

namespace SkyForge.MVVM.Binders
{
    public class FloatToBoolUnityEventBinder : ObservableBinder<float>
    {
        [SerializeField] private CompareOperation m_compareOperation;
        [SerializeField] private float m_compareValue;
        [SerializeField] private UnityEvent<bool> m_event;
        [SerializeField] private UnityEvent<object, bool> m_eventWithAnalitics;
        protected override void OnPropertyChanged(object sender, float newValue)
        {
            var result = m_compareOperation.Compare(newValue, m_compareValue);
            m_event?.Invoke(result);
            m_eventWithAnalitics?.Invoke(sender, result);
        }
    }
}