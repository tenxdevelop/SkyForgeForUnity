/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.MVVM
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SubViewModelAttribute : Attribute
    {
        public Type AcctualType { get; private set; }
        public SubViewModelAttribute(Type acctualType)
        {
            if (!typeof(IViewModel).IsAssignableFrom(acctualType))
                UnityEngine.Debug.LogError($"Can't find SubViewModel: {acctualType.Name}");
            AcctualType = acctualType;
        }
    }
}
