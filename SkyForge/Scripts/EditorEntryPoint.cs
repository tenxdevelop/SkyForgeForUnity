/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
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
                    var defineAssemblySettings = Resources.Load<DefineAssemblyProject>("DefineAssemblyProject");

                    if (defineAssemblySettings != null)
                    {
                        SkyForgeDefineAssembly.SetAssemblyName(defineAssemblySettings.AssemblyName);
                        SessionState.SetString("AssemblyDefine", defineAssemblySettings.AssemblyName);
                    }
                    else
                    {
                        Debug.LogWarning("Create assembly define in root resources folder");
                        SkyForgeDefineAssembly.SetAssemblyName("Assembly-CSharp");
                        SessionState.SetString("AssemblyDefine", "Assembly-CSharp");
                    }
                }
                catch (Exception exception)
                {
                    Debug.Log("don't have assembly config, please set default or custom assembly definition, error: " + exception);
                }
                
                Debug.Log("SkyForge Init.");
                
                SessionState.SetBool("FirstInitDone", true);
            }
        }
    }
}

#endif