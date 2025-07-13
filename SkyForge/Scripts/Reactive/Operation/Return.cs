/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Reactive.Extension
{
    public static partial class Observable
    {
        public static IObservable<T> Return<T>(T value)
        {
            return new ImmediateScheduleReturn<T>(value);
        }
    }

    internal class ImmediateScheduleReturn<T> : IObservable<T>
    {
        private T m_value;
        internal ImmediateScheduleReturn(T value)
        {
            m_value = value;
        }

        public IBinding Subscribe(IObserver<T> observer)
        {
            observer.NotifyObservableChanged(null, m_value);
            return null;
        }

        public void Unsubscribe(IObserver<T> observer)
        {

        }
    }
}
