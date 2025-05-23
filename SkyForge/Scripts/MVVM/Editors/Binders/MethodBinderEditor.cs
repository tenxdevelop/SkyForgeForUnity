﻿/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using System.Collections.Generic;

namespace SkyForge.MVVM.Editors
{
    public abstract class MethodBinderEditor : BinderEditor
    {
        protected sealed override IEnumerable<string> GetPropertyNames()
        {
            return GetMethodNames();
        }

        protected abstract IEnumerable<string> GetMethodNames();
    }
}

#endif