/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Reflection;
using System;

namespace SkyForge
{
    public static class SkyForgeDefineAssembly
    {
        public const string ASSEMBLY_CONFIG_FILE_NAME = "SkyForgeDefineAssemblyConfig.json";
        public static string m_assemblyName = "Assembly-CSharp";
        
        private static Assembly m_assembly;

        public static string GetAssemblyName()
        {
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
