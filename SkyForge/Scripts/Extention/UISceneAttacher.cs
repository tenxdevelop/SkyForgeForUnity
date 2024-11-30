/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM;
using UnityEngine;

namespace SkyForge.Extention
{
    public class UISceneAttacher : MonoBehaviour
    {
        public void AttachSceneUI(View uIview)
        {
            uIview.transform.SetParent(transform, false);
        }

        public void ClearSceneUI()
        {
            var childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
        }
    }
}
