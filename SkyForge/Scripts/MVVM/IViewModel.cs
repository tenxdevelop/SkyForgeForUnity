/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.MVVM
{
    public interface IViewModel : IDisposable
    {
        TViewModel As<TViewModel>() where TViewModel : IViewModel;
        void Update(float deltaTime);
        void PhysicsUpdate(float deltaTime);
    }
}
