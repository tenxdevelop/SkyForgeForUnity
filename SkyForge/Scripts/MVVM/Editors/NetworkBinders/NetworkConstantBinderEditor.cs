/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM.NetworkBinders;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SkyForge.MVVM.Editors
{
	[CustomEditor(typeof(NetworkConstantBinder), true)]
    public class NetworkConstantBinderEditor : NetworkBinderEditor
    {
        private NetworkConstantBinder m_networkConstantBinder;
        protected override void OnStart()
        {
            m_networkConstantBinder = target as NetworkConstantBinder;
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
            if(propertyType.GetGenericArguments().First() != m_networkConstantBinder.ArgumentType)
                return false;

            return propertyType.GetInterfaces().Any(i => typeof(IConstantProperty<>)
                .IsAssignableFrom(i.GetGenericTypeDefinition()));
        }
    }
}