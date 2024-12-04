/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Reflection;
using UnityEditor;
using UnityEngine;
using System.IO;
using System;

namespace SkyForge.FlatBuffers
{
    public static class FlatBuffersMenu
    {
        private static IFlatBuffersScriptGenerated m_flatBuffersScriptGenerated;

        [MenuItem("SkyForge/FlatBuffers/Compile FlatBuffers Scehemas")]
        public static void CompileFlatBuffersScehemas()
        {
            if (m_flatBuffersScriptGenerated is null)
            {
                Debug.Log("Error can't set FlatBuffers Script Generated");
                return;
            }           
            FlatCompiler.Compile(m_flatBuffersScriptGenerated.GetSchemaPaths(), m_flatBuffersScriptGenerated.GetOutputDirectory());
        }

        [MenuItem("SkyForge/FlatBuffers/Set FlatBuffers Scripts")]
        public static void SetFlatBuffersScripts()
        {
            var scriptPath = EditorUtility.OpenFilePanel("Select Script", "Assets", "cs");

            if (string.IsNullOrEmpty(scriptPath))
            {
                Debug.LogError("FlatBuffers script path is empty!");
                return;
            }

            var nameSpace = ReadNameSpace(scriptPath);
            var scriptName = Path.GetFileNameWithoutExtension(scriptPath);
            var FullScriptName = nameSpace + "." + scriptName;

            var assembly = GetPlayerAssembly();
            if (assembly is null)
            {
                Debug.Log("Error can't find Assembly Player");
                return;
            }

            var scriptType = assembly.GetType(FullScriptName);

            if (scriptType is null)
            {
                Debug.LogError("FlatBuffers script type is empty!");
                return;
            }

            if (!typeof(IFlatBuffersScriptGenerated).IsAssignableFrom(scriptType))
            {
                Debug.LogError("Script is not assignable IFlatBuffersScriptGenerated");
                return;
            }

            m_flatBuffersScriptGenerated = Activator.CreateInstance(scriptType) as IFlatBuffersScriptGenerated;
            Debug.Log("Script seted successfully!");
        }

        private static string ReadNameSpace(string scriptPath)
        {
            var nameSpaceLine = "namespace ";
            try
            {
                using (StreamReader streamReader = new StreamReader(scriptPath))
                {
                    var line = streamReader.ReadLine();
                    while (!line.Contains("namespace"))
                        line = streamReader.ReadLine();

                    line = line.Remove(0, nameSpaceLine.Length);
                    return line;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error can't read FlatBuffers Script Generated! Error: {ex}");
                return null;
            }
        }

        private static Assembly GetPlayerAssembly()
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
