/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using UnityEditor.Experimental.GraphView;
using SkyForge.MVVM.NetworkBinders;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace SkyForge.MVVM.Editors
{
    [CustomEditor(typeof(NetworkBinder), true)]
    public abstract class NetworkBinderEditor : Editor
    {
        protected SerializedProperty PropertyName => m_propertyName;
        protected SerializedProperty MethodName => m_propertyName;
        protected SerializedProperty ViewModelTypeFullName => m_viewModelTypeFullName;

        private NetworkBinder m_binder;
        private BaseNetworkView m_parentView;
        private SerializedProperty m_viewModelTypeFullName;
        private SerializedProperty m_propertyName;

        private void OnEnable()
        {
            m_binder = target as NetworkBinder;
            m_parentView = m_binder.GetComponentInParent<BaseNetworkView>();
            m_viewModelTypeFullName = serializedObject.FindProperty(nameof(m_viewModelTypeFullName));
            m_propertyName = serializedObject.FindProperty(nameof(m_propertyName));
            OnStart();
        }

        public override void OnInspectorGUI()
        {

            if (!m_viewModelTypeFullName.stringValue.Equals(m_parentView.ViewModelTypeFullName))
            {
                m_viewModelTypeFullName.stringValue = m_parentView.ViewModelTypeFullName;
                serializedObject.ApplyModifiedProperties();
            }

            if (string.IsNullOrEmpty(m_viewModelTypeFullName.stringValue))
            {
                EditorGUILayout.HelpBox(MVVMConstant.WARNING_VIEW, MessageType.Warning);
                return;
            }

            base.OnInspectorGUI();
            UpInspectorGUI();
            DrawPropertyName();

            DownInspectorGUI();
            
        }
        
        protected void DrawPropertyName()
        {
            var options = GetPropertyNames().ToArray();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(GetLabelField());

            if (GUILayout.Button(string.IsNullOrEmpty(MethodName.stringValue) ? MVVMConstant.NONE : MethodName.stringValue, EditorStyles.popup))
            {
                var provider = CreateInstance<StringListSearchProvider>();
                provider.Init(options, OnPressedSearch);
                SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)), provider);
            }

            EditorGUILayout.EndHorizontal();
        }

        protected abstract IEnumerable<string> GetPropertyNames();

        protected virtual void UpInspectorGUI() { }

        protected virtual void DownInspectorGUI() { }
        protected virtual void OnStart() { }
        
        protected virtual string GetLabelField() => MVVMConstant.PROPERTY_NAME;
        
        private void OnPressedSearch(string newPropertyName)
        {
            PropertyName.stringValue = newPropertyName == MVVMConstant.NONE ? null : newPropertyName;
            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif