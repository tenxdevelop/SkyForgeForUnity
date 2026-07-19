/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.NetworkBinders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_NETWORK_METHOD_BINDER +
                      "On collision network exit empty binder")]
    public class OnCollisionNetworkExitEmptyBinder : OnTriggerNetworkEmptyBinder
    {
        private void OnCollisionExit(Collision collision)
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
            
            var view = collision.gameObject.GetComponent(m_triggerViewType);
            if (view)
            {
                m_action?.Invoke(view);
            }
        }
    }
}