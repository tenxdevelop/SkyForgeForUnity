/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.Binders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_METHOD_BINDER + 
                      "On trigger exit method binder")]
    public class OnTriggerExitEmptyBinder : TriggerOnTriggerEmptyBinder
    {
        private void OnTriggerExit(Collider other)
        {
            if (m_triggerViewType is null)
            {
                return;
            }

            if (m_triggerViewType.FullName.Equals(MVVMConstant.ANY_VIEW_TYPE))
            {
                m_action?.Invoke(null);
                return;
            }
            
            var view = other.GetComponent(m_triggerViewType);
            if (view)
            {
                m_action?.Invoke(view);
            }
        }
    }
}