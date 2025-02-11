/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System.IO;
using System;

namespace SkyForge
{
    [InitializeOnLoad]
    public class EditorEntryPoint
    {
        static EditorEntryPoint ()
        {
            if (!SessionState.GetBool("FirstInitDone", false))
            {
                
                try
                {
                    var currentDirectory = Directory.GetCurrentDirectory();
                    var jsonText = File.ReadAllText(Path.Combine(currentDirectory, SkyForgeDefineAssembly.ASSEMBLY_CONFIG_FILE_NAME));
                    var assemblyDto = JsonUtility.FromJson<AssemblyDto>(jsonText);
                    SkyForgeDefineAssembly.LoadCustomAssembly(assemblyDto);
                }
                catch (Exception e)
                {
                    Debug.Log("don't have assembly config, please set default or custom assembly definition");
                }
                
                Debug.Log("SkyForge Init.");
                
                SessionState.SetBool("FirstInitDone", true);
            }
        }
    }
}

#endif
