/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Reactive
{
    public interface IObserver<in T> : IDisposable
    {
        void NotifyObservableChanged(object sender, T value);
    }
}
