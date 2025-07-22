/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.Binders
{
    public class OnTriggerStayEmptyBinder : TriggerOnTriggerEmptyBinder
    {
        private void OnTriggerStay(Collider other)
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
            
            var view = other.GetComponent(m_trigerViewType);
            if (view)
            {
                m_action?.Invoke(view);
            }
        }
    }
}