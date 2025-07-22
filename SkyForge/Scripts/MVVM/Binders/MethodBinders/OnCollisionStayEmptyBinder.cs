/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.Binders
{
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