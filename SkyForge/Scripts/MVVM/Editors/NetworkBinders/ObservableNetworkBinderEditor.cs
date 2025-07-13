/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using SkyForge.MVVM.NetworkBinders;
using System.Collections.Generic;
using SkyForge.Reactive;
using System.Linq;
using UnityEditor;

namespace SkyForge.MVVM.Editors
{
    [CustomEditor(typeof(ObservableNetworkBinder), true)]
    public class ObservableNetworkBinderEditor : NetworkBinderEditor
    {
        private ObservableNetworkBinder m_observableBinder;
        protected override void OnStart()
        {
            m_observableBinder = target as ObservableNetworkBinder;
        }
        protected override IEnumerable<string> GetPropertyNames()
        {
            var properties = new List<string>() { MVVMConstant.NONE };

            return properties.Concat(SkyForgeDefineAssembly.GetPlayerAssembly().GetType(ViewModelTypeFullName.stringValue).GetProperties()
                .Where(property => property.PropertyType.IsGenericType)
                .Where(property => IsValidProperty(property.PropertyType))
                .Select(property => property.Name)
                .OrderBy(name => name));
        }

        private bool IsValidProperty(System.Type propertyType)
        {
            if(propertyType.GetGenericArguments().First() != m_observableBinder.ArgumentType)
                return false;

            return propertyType.GetInterfaces().Where(i => i.IsGenericType)
                .Any(i => typeof(IObservable<>).IsAssignableFrom(i.GetGenericTypeDefinition()) ||
                          typeof(IObservableCollection<>).IsAssignableFrom(i.GetGenericTypeDefinition()));
        }
    }
}

#endif