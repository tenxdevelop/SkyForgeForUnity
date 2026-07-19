/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using SkyForge.MVVM.NetworkBinders;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEditor;

namespace SkyForge.MVVM.Editors
{
    [CustomEditor(typeof(OnTriggerNetworkEmptyBinder), true)]
    public class OnTriggerNetworkEmptyBinderEditor : OnTriggerNetworkMethodBinderEditor
    {
        protected override IEnumerable<string> GetMethodNames()
        {
            var methodNames = new List<string>() { MVVMConstant.NONE };
            
            return methodNames.Concat(m_viewModelType.GetMethods()
                .Where(method => method.GetParameters().Length == 1 &&
                                 method.GetParameters().First().ParameterType == typeof(object) &&
                                 method.ReturnType == typeof(void))
                .Where(method => method.GetCustomAttribute(typeof(ReactiveMethodAttribute)) is ReactiveMethodAttribute)
                .Select(property => property.Name)
                .OrderBy(name => name));
        }
    }
}

#endif