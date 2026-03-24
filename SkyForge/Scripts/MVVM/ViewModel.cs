/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.MVVM
{
    public abstract class ViewModel : IViewModel
    {
        public TViewModel As<TViewModel>() where TViewModel : IViewModel
        {
            return (TViewModel)(object)this;
        }
        
        public virtual void Update(float deltaTime)
        {
            
        }

        public virtual void PhysicsUpdate(float deltaTime)
        {
            
        }

        public virtual void Dispose()
        {
            
        }
    }
}
