/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.Events;
using SkyForge.Reactive;
using UnityEngine;
using System;

namespace SkyForge.MVVM.Binders
{
    public abstract class ConstantBinder : Binder
    {
        public abstract Type ArgumentType { get; }
    }
    
    public abstract class ConstantBinder<T> : ConstantBinder
    {
        public override Type ArgumentType => typeof(T);
        
        [SerializeField] private UnityEvent<T> m_bindConstantEvent;
        protected override IBinding BindInternal(IViewModel viewModel)
        {
            var propertyInfo = viewModel.GetType().GetProperty(PropertyName);
            var constantProperty = propertyInfo.GetValue(viewModel) as IConstantProperty<T>;
            m_bindConstantEvent?.Invoke(constantProperty.Value);
            return null;
        }
    }
}