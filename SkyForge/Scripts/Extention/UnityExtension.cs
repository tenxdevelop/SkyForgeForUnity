/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.Extension
{
    public static class UnityExtension
    {
        public static IEntryPoint GetEntryPoint<T>() where T : MonoBehaviour, IEntryPoint
        {
            return Object.FindFirstObjectByType<T>();
        }

#if UNITY_EDITOR
        public static T AddComponentInEditor<T>(Transform transform) where T : Component
        {
            if (transform.GetComponent<T>() == null)
                transform.gameObject.AddComponent<T>();
            
            return transform.GetComponent<T>();
        }
#endif

    }
}
