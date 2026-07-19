/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using System.Collections.Generic;

namespace SkyForge.MVVM.Editors
{
    public abstract class NetworkMethodBinderEditor : NetworkBinderEditor
    {
        protected sealed override IEnumerable<string> GetPropertyNames()
        {
            return GetMethodNames();
        }
        
        protected abstract IEnumerable<string> GetMethodNames();
        
        protected override string GetLabelField() => MVVMConstant.METHOD_NAME;
    }
}

#endif