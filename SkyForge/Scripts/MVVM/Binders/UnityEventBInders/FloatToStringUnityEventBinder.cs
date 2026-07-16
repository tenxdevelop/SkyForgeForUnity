/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.Events;
using UnityEngine;

namespace SkyForge.MVVM.Binders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_REACTIVE_BINDER +
                      "Float to string unity event binder")]
    public class FloatToStringUnityEventBinder : ObservableBinder<float>
    {
        [SerializeField] private string m_textBefore = string.Empty;
        [SerializeField] private string m_textAfter = string.Empty;
        [SerializeField] private UnityEvent<string> m_event;
        [SerializeField] private UnityEvent<object, string> m_eventWithAnalitics;
        protected override void OnPropertyChanged(object sender, float newValue)
        {
            var result = m_textBefore + newValue.ToString() + m_textAfter;
            m_event?.Invoke(result);
            m_eventWithAnalitics?.Invoke(sender, result);
        }
    }
}