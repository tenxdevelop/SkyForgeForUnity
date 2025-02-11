/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Reflection;
using UnityEngine;
using System.IO;
using System;

namespace SkyForge
{
    public static class SkyForgeDefineAssembly
    {
        public const string ASSEMBLY_CONFIG_FILE_NAME = "SkyForgeDefineAssemblyConfig.json";
        private static string m_assemblyName = "Assembly-CSharp";
        private static Assembly m_assembly;
        public static void SetCustomAssembly(string assemblyName)
        {
            m_assemblyName = assemblyName;
            
            var assembly = new AssemblyDto() { assemblyName = m_assemblyName };
            var jsonText = JsonUtility.ToJson(assembly);
            
            var currentDirectory = Directory.GetCurrentDirectory();
            File.WriteAllText(Path.Combine(currentDirectory, ASSEMBLY_CONFIG_FILE_NAME), jsonText);
            
            m_assembly = null;
        }

        public static void LoadCustomAssembly(AssemblyDto assemblyDto)
        {
            m_assemblyName = assemblyDto.assemblyName;
            m_assembly = null;
        }
        
        public static string GetAssemblyName() => m_assemblyName;
        
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
