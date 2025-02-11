/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;
using System.IO;

namespace SkyForge
{
    public static class CustomAssemblyMenu
    {
        private const string DEFAULT_ASSEMBLY_NAME = "Assembly-CSharp";
        
        [MenuItem("SkyForge/Custom Assembly/Set Custom Assembly")]
        public static void SetCustomAssembly()
        {
            string assemblyPath = EditorUtility.OpenFilePanel("Выберите asmdef файл", "", "asmdef");

            SetCustomAssembly(assemblyPath);
        }

        [MenuItem("SkyForge/Custom Assembly/Set Default Assembly")]
        public static void ResetCustomAssembly()
        {
            SkyForgeDefineAssembly.SetCustomAssembly(DEFAULT_ASSEMBLY_NAME);
        }
        
        [MenuItem("SkyForge/Custom Assembly/Show Assembly Definition")]
        public static void ShowAssemblyDefinition()
        {
            Debug.Log("Assembly: " + SkyForgeDefineAssembly.GetAssemblyName());
        }
        
        private static void SetCustomAssembly(string assemblyPath)
        {
            if (string.IsNullOrEmpty(assemblyPath))
            {
                Debug.LogError("Assembly definition path is null or empty!");
                return;
            }
            
            var jsonText = File.ReadAllText(assemblyPath);
            var json = JObject.Parse(jsonText);

            var assemblyName = json["name"].ToString();
            
            SkyForgeDefineAssembly.SetCustomAssembly(assemblyName);
        }
    }
}

#endif