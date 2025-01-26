/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using System.Collections.Generic;
using SkyForge.MVVM.Binders;
using System.Reflection;
using System.Linq;
using UnityEditor;

namespace SkyForge.MVVM.Editors
{
    [CustomEditor(typeof(OnTriggerEmptyBinder), true)]
    public class OnTriggerEmptyBinderEditor : OnTriggerMethodBinderEditor
    {
        protected override IEnumerable<string> GetMethodNames()
        {
            var methodNames = new List<string>() { MVVMConstant.NONE };
            return methodNames.Concat(SkyForgeDefineAssembly.GetPlayerAssembly().GetType(ViewModelTypeFullName.stringValue).GetMethods()
                              .Where(method => method.GetParameters().Length == 1 &&
                                     method.GetParameters().First().ParameterType == typeof(object) &&
                                     method.ReturnType == typeof(void))
                              .Where(method => method.GetCustomAttribute(typeof(ReactiveMethodAttribute)) is ReactiveMethodAttribute)
                              .Select(property => property.Name)
                              .OrderBy(name => name));
        }

        protected override string GetLabelField() => MVVMConstant.METHOD_NAME;
    }
}

#endif
