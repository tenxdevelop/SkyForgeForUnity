/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Reactive.Extension
{
    public static class ObservableSubscribeExtension
    {
        public static IBinding Subscribe<T>(this IObservable<T> observable, Action action)
        {
            return observable.Subscribe(new AnonymousObserver<T>(action));
        }

        public static IBinding Subscribe<T>(this IObservable<T> observable, Action<T> action)
        {
            return observable.Subscribe(new AnonymousObserver<T>(action));
        }

        public static IBinding Subscribe<T>(this IObservable<T> observable, Action<object, T> action)
        {
            return observable.Subscribe(new AnonymousObserver<T>(action));
        }

    }

    internal sealed class AnonymousObserver<T> : IObserver<T>
    {
        private Action m_actionWithoutParams;
        private Action<T> m_actionWithParams;
        private Action<object, T> m_actionWithParamsAndAnalitics;

        internal AnonymousObserver(Action actonWithouParams) : this(actonWithouParams, null, null) { }
        internal AnonymousObserver(Action<T> actionWithParams) : this(null, actionWithParams, null) { }
        internal AnonymousObserver(Action<object, T> actionWithParamsAndAnalitics) : this(null, null, actionWithParamsAndAnalitics) { }

        internal AnonymousObserver(Action actonWithouParams, Action<T> actionWithParams, Action<object, T> actionWithParamsAndAnalitics)
        {
            m_actionWithoutParams = actonWithouParams;
            m_actionWithParams = actionWithParams;
            m_actionWithParamsAndAnalitics = actionWithParamsAndAnalitics;
        }

        public void Dispose()
        {
            m_actionWithoutParams = null;
            m_actionWithParams = null;
            m_actionWithParamsAndAnalitics = null;
        }

        public void NotifyObservableChanged(object sender, T value)
        {
            m_actionWithoutParams?.Invoke();
            m_actionWithParams?.Invoke(value);
            m_actionWithParamsAndAnalitics?.Invoke(sender, value);
        }
    }
}
