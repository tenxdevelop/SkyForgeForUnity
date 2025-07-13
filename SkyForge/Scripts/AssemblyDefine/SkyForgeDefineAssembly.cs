/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Reflection;
using UnityEditor;
using UnityEngine;
using System.IO;
using System;

namespace SkyForge
{
    public static class SkyForgeDefineAssembly
    {
        public const string ASSEMBLY_CONFIG_FILE_NAME = "SkyForgeDefineAssemblyConfig.json";
        public const string ASSEMBLY_DEFAULT = "Assembly-CSharp";

        private static string m_assemblyName = String.Empty;
        
        private static Assembly m_assembly;
        
#if UNITY_EDITOR
        public static void SetCustomAssembly(string assemblyName)
        {
            m_assemblyName = assemblyName;
            SessionState.SetString("AssemblyDefine", assemblyName);
            
            var assemblyDto = new AssemblyDto() { assemblyName = assemblyName };
            var jsonText = JsonUtility.ToJson(assemblyDto);
            
            var currentDirectory = Directory.GetCurrentDirectory();
            File.WriteAllText(Path.Combine(currentDirectory, ASSEMBLY_CONFIG_FILE_NAME), jsonText);
            
            m_assembly = null;
        }

        public static void LoadCustomAssembly(AssemblyDto assemblyDto)
        {
            m_assemblyName =  assemblyDto.assemblyName;
            SessionState.SetString("AssemblyDefine", assemblyDto.assemblyName);
            m_assembly = null;
        }
        
#endif
        public static string GetAssemblyName()
        {
            if (string.IsNullOrEmpty(m_assemblyName))
            {
                m_assemblyName = SessionState.GetString("AssemblyDefine", ASSEMBLY_DEFAULT);
            }
            
            return m_assemblyName;   
        }
        
        public static Assembly GetPlayerAssembly()
        {
            
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
