/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.NetworkBinders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_NETWORK_METHOD_BINDER +
                      "On trigger network exit empty binder")]
    public class OnTriggerNetworkExitEmptyBinder : OnTriggerNetworkEmptyBinder
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