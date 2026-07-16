/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.Binders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_METHOD_BINDER + 
                      "On collision stay method binder")]
    public class OnCollisionStayEmptyBinder : CollisionOnTriggerEmptyBinder
    {
        private void OnCollisionStay(Collision collision)
        {
            if (m_trigerViewType is null)
            {
                return;
            }

            if (m_trigerViewType.FullName.Equals(MVVMConstant.ANY_VIEW_TYPE))
            {
                m_action?.Invoke(null);
                return;
            }
            
            var view = collision.gameObject.GetComponent(m_trigerViewType);
            if (view)
            {
                m_action?.Invoke(view);
            }
        }
    }
}