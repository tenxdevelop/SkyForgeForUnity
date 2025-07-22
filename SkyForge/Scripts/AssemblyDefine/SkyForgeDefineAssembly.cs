/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Reflection;
using UnityEditor;
using UnityEngine;
using System;

namespace SkyForge
{
    public static class SkyForgeDefineAssembly
    {
        private static string m_assemblyName;
        
        private static Assembly m_assembly;

        public static string GetAssemblyName()
        {
            return m_assemblyName;
        }

        public static void SetAssemblyName(string assemblyName)
        {
            m_assemblyName = assemblyName;
        }
        
        public static Assembly GetPlayerAssembly()
        {

#if UNITY_EDITOR
            if (string.IsNullOrEmpty(m_assemblyName))
            {
                SetAssemblyName(SessionState.GetString("AssemblyDefine", "Assembly-CSharp"));
                Debug.Log(m_assemblyName);
            }
#endif
            if (m_assembly is null)
            {
                var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                
                foreach (var assembly in allAssemblies)
                {
                    if (assembly.FullName.Contains(m_assemblyName))
                        m_assembly = assembly;
                }
            }
            
            return m_assembly;
        }
    }
}
