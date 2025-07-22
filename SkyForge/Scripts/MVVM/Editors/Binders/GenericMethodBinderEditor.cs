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
    [CustomEditor(typeof(GenericMethodBinder), true)]
    public class GenericMethodBinderEditor : MethodBinderEditor
    {
        private GenericMethodBinder m_genericMethodBinder;
        protected override void OnStart()
        {
            m_genericMethodBinder = target as GenericMethodBinder;
        }

        protected override IEnumerable<string> GetMethodNames()
        {
            var methodNames = new List<string>() { MVVMConstant.NONE };
            
            
            return methodNames.Concat(m_viewModelType.GetMethods()
                                     .Where(method => method.GetParameters().Length == 2 && method.ReturnType == typeof(void))
                                     .Where(method => method.GetCustomAttribute(typeof(ReactiveMethodAttribute)) is ReactiveMethodAttribute)
                                     .Where(method => method.GetParameters().First().ParameterType == typeof(object) &&
                                                      method.GetParameters().Last().ParameterType == m_genericMethodBinder.ArgumentType)
                                     .Select(property => property.Name)
                                     .OrderBy(name => name));
        }

        protected override string GetLabelField() => MVVMConstant.METHOD_NAME;
        
    }
}

#endif
