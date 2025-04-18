﻿/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Extension;
using UnityEngine;
using System;

namespace SkyForge.MVVM.Binders
{
    public abstract class OnTriggerEmptyBinder : EmptyMethodBinder
    {
        [SerializeField, HideInInspector] private string m_trigerViewTypeFullName;
        protected Type m_trigerViewType;

        private void Awake()
        {
#if UNITY_EDITOR
            if (!UnityEditor.EditorApplication.isPlaying)
            {
                UnityExtension.AddComponentInEditor<Rigidbody>(transform);
                transform.GetComponent<Rigidbody>().useGravity = false;
            }         
#endif
            OnAwake();
        }
        protected virtual void OnAwake() { }
        protected override void OnBind()
        {
            m_trigerViewType = Type.GetType(m_trigerViewTypeFullName);
        }
    }
}
