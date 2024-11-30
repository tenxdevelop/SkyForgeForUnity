/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Reactive
{
    public interface IObservable<out T>
    {
        IBinding Subscribe(IObserver<T> observer);
        void Unsubscribe(IObserver<T> observer);
    }
}
