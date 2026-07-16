/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using SkyForge.MVVM.Binders;
using System.Linq;
using UnityEditor;

namespace SkyForge.MVVM.Editors
{
    [CustomEditor(typeof(ConstantBinder), true)]
    public class ConstantBinderEditor : BinderEditor
    {
        private ConstantBinder m_constantBinder;
        protected override void OnStart()
        {
            m_constantBinder = target as ConstantBinder;
        }
        protected override IEnumerable<string> GetPropertyNames()
        {
            var properties = new List<string>() { MVVMConstant.NONE };
            return properties.Concat(m_viewModelType.GetProperties()
                .Where(property => property.PropertyType.IsGenericType)
                .Where(property => IsValidProperty(property.PropertyType))
                .Select(property => property.Name)
                    .OrderBy(name => name));
        }

        private bool IsValidProperty(System.Type propertyType)
        {
            if(propertyType.GetGenericArguments().First() != m_constantBinder.ArgumentType)
                return false;

            return propertyType.GetInterfaces().Any(i => typeof(IConstantProperty<>)
                .IsAssignableFrom(i.GetGenericTypeDefinition()));
        }
    }
}