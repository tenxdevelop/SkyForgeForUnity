/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace SkyForge.Proxy
{
    public interface IStateProvider<TProxy> : System.IDisposable where TProxy : IProxy
    {
        TProxy ProxyState { get; }

        IObservable<bool> SaveState();

        IObservable<bool> ResetState();

        IObservable<TProxy> LoadState();
    }
}
