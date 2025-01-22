/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using System.Reflection;

namespace SkyForge
{
    public static class SkyForgeDefineAssembly
    {
        public static Assembly GetPlayerAssembly()
        {
            Assembly result = null;
            var allAsemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in allAsemblies)
            {
                if (assembly.FullName.Contains("Assembly-CSharp"))
                    result = assembly;
            }
            return result;
                  
        }
    }
}
