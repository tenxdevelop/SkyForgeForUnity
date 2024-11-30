/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using System.IO;
using System;

namespace SkyForge.Infrastructure.FlatBuffers
{
    public static class FlatCompiler
    {
        private const string FLATC_PATH = "Assets/SkyForge/FlatBuffers/flatc";

        public static void Compile(string schemePath, string outputDirectory)
        {
            DeleteCompileCode(outputDirectory);

            var arguments = $"--csharp --gen-object-api -o \"{outputDirectory}\" \"{schemePath}\"";

            Compile(arguments);
        }

        public static void Compile(IEnumerable<string> shemePaths, string outputDirectory)
        {
            DeleteCompileCode(outputDirectory);

            var schemePathsSingleLine = "";

            foreach (var shemePath in shemePaths)
                schemePathsSingleLine += $"\"{shemePath}\" ";
            
            var arguments = $"--csharp --gen-object-api -o \"{outputDirectory}\" {schemePathsSingleLine}";

            Compile(arguments);
        }

        private static void Compile(string arguments)
        {
            UnityEngine.Debug.Log("Start FlatBuffers commpilation schemas");

            try
            {
                var processInfo = new ProcessStartInfo()
                {
                    FileName = FLATC_PATH,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(processInfo))
                {
                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        UnityEngine.Debug.LogError($"FlatBuffers compiled failed with errors: {error}");
                        return;
                    }

                    UnityEngine.Debug.Log("FlatBuffers compiled successfully\n" + output);
                    AssetDatabase.Refresh();
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"Error can't compile FlatBuffers schemas, Error: {ex}");
            }

        }

        private static void DeleteCompileCode(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }

            Directory.CreateDirectory(directoryPath);
        }

    }
}
