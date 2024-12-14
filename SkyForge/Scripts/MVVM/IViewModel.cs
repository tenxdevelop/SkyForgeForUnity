/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.MVVM
{
    public interface IViewModel : IDisposable
    {
        void Update(float deltaTime);
        void PhysicsUpdate(float deltaTime);
    }
}
