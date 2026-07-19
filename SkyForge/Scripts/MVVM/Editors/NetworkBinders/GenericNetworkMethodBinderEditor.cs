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
    [CustomEditor(typeof(GenericNetworkMethodBinder), true)]
    public class GenericNetworkMethodBinderEditor : NetworkMethodBinderEditor
    {
        private GenericNetworkMethodBinder m_genericNetworkMethodBinder;
        
        protected override void OnStart()
        {
            m_genericNetworkMethodBinder = target as GenericNetworkMethodBinder;
        }
        
        protected override IEnumerable<string> GetMethodNames()
        {
            var methodNames = new List<string>() { MVVMConstant.NONE };
            
            return methodNames.Concat(m_viewModelType.GetMethods()
                .Where(method => method.GetParameters().Length == 2 && method.ReturnType == typeof(void))
                .Where(method => method.GetCustomAttribute(typeof(ReactiveMethodAttribute)) is ReactiveMethodAttribute)
                .Where(method => method.GetParameters().First().ParameterType == typeof(object) &&
                                 method.GetParameters().Last().ParameterType == m_genericNetworkMethodBinder.ArgumentType)
                .Select(property => property.Name)
                .OrderBy(name => name));
        }
    }
}

#endif