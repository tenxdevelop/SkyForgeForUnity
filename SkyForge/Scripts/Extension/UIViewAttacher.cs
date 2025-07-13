/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SkyForge.Extension
{
    public class UIViewAttacher : MonoBehaviour
    {
        private List<UIScreenView> m_uIScreenViewsMap = new();
        
        public void AttachSceneUI(UIScreenView uIScreenView)
        {
            uIScreenView.transform.SetParent(transform, false);
            m_uIScreenViewsMap.Add(uIScreenView);
        }

        public void ClearContainerUIScreenView()
        {
            var childCount = transform.childCount;
            
            foreach(var uIScreenView in m_uIScreenViewsMap)
                Destroy(uIScreenView.gameObject);
            
            m_uIScreenViewsMap.Clear();
        }

        public void DetachSceneUI(UIScreenView uIScreenView)
        {
            var viewDetach = m_uIScreenViewsMap.FirstOrDefault(view => view == uIScreenView);

            if (viewDetach is not null)
            {
                Destroy(viewDetach.gameObject);
                m_uIScreenViewsMap.Remove(uIScreenView);
            }
        }
    }
}
