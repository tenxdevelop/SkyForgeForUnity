/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using Unity.VisualScripting;
using UnityEngine;

namespace SkyForge.Extention
{
    public static class UnityExtention
    {
        public static IEntryPoint GetEntryPoint<T>() where T : MonoBehaviour, IEntryPoint
        {
            return Object.FindFirstObjectByType<T>();
        }

#if UNITY_EDITOR
        public static T AddComponentInEditor<T>(Transform transform) where T : Component
        {

            if (transform.GetComponent<T>() == null)
                transform.AddComponent<T>();
            return transform.GetComponent<T>();
        }
#endif

    }
}
