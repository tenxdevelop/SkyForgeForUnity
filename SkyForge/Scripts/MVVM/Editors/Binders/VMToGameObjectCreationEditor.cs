/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using System.Collections.Generic;
using SkyForge.MVVM.Binders;
using System.Linq;
using UnityEditor;

namespace SkyForge.MVVM.Editors
{
    [CustomEditor(typeof(VMToGameObjectCreation))]
    public class VMToGameObjectCreationEditor : BinderEditor
    {
        protected override IEnumerable<string> GetPropertyNames()
        {
            var properties = new List<string>() { MVVMConstant.NONE };
            
            return properties.Concat(m_viewModelType.GetProperties()
                             .Where(property => !property.PropertyType.IsGenericType)
                             .Where(property => typeof(IViewModel).IsAssignableFrom(property.PropertyType))
                             .Select(property => property.Name)
                             .OrderBy(name => name));
        }
        
    }
    
}

#endif
