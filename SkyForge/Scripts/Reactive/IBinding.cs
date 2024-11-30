/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Reactive
{
    public interface IBinding : IDisposable
    {
        void Binded();
    }
}
