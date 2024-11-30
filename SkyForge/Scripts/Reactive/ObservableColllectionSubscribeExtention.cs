/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Reactive.Extention
{
    public static class ObservableColllectionSubscribeExtention
    {
        public static IBinding Subscribe<T>(this IObservableCollection<T> observableCollection, Action actionAdded, Action actionRemoved, Action actionClear)
        {
            return observableCollection.Subscribe(new AnonymousObserverCollection<T>(actionAdded, actionRemoved, actionClear));
        }

        public static IBinding Subscribe<T>(this IObservableCollection<T> observableCollection, Action<T> actionAdded, Action<T> actionRemoved, Action actionClear)
        {
            return observableCollection.Subscribe(new AnonymousObserverCollection<T>(actionAdded, actionRemoved, actionClear));
        }

        public static IBinding Subscribe<T>(this IObservableCollection<T> observableCollection, Action<object, T> actionAdded, Action<object, T> actionRemoved, Action<object> actionClear)
        {
            return observableCollection.Subscribe(new AnonymousObserverCollection<T>(actionAdded, actionRemoved, actionClear));
        }

        public static IBinding SubscribeAdded<T>(this IObservableCollection<T> observableCollection, Action actionAdded)
        {
            return observableCollection.Subscribe(new AnonymousObserverCollection<T>(actionAdded, null, null));
        }

        public static IBinding SubscribeAdded<T>(this IObservableCollection<T> observableCollection, Action<T> actionAdded)
        {
            return observableCollection.Subscribe(new AnonymousObserverCollection<T>(actionAdded, null, null));
        }

        public static IBinding SubscribeAdded<T>(this IObservableCollection<T> observableCollection, Action<object, T> actionAdded)
        {
            return observableCollection.Subscribe(new AnonymousObserverCollection<T>(actionAdded, null, null));
        }

        public static IBinding SubscribeRemoved<T>(this IObservableCollection<T> observableCollection, Action actionRemoved)
        {
            return observableCollection.Subscribe(new AnonymousObserverCollection<T>(null, actionRemoved, null));
        }

        public static IBinding SubscribeRemoved<T>(this IObservableCollection<T> observableCollection, Action<T> actionRemoved)
        {
            return observableCollection.Subscribe(new AnonymousObserverCollection<T>(null, actionRemoved, null));
        }

        public static IBinding SubscribeRemoved<T>(this IObservableCollection<T> observableCollection, Action<object, T> actionRemoved)
        {
            return observableCollection.Subscribe(new AnonymousObserverCollection<T>(null, actionRemoved, null));
        }
    }


    internal sealed class AnonymousObserverCollection<T> : IObserverCollection<T>
    {
        private Action m_actionAddedWithoutParams;
        private Action<T> m_actionAddedWithParams;
        private Action<object, T> m_actionAddedWithParamsAndAnalitics;

        private Action m_actionClearWithoutParams;
        private Action<object> m_actionClearWithParams;

        private Action m_actionRemovedWithoutParams;
        private Action<T> m_actionRemovedWithParams;
        private Action<object, T> m_actionRemovedWithParamsAndAnalitics;

        internal AnonymousObserverCollection(Action actionAdded, Action actionRemoved, Action actionClear) :  this(actionAdded, actionClear, actionRemoved, 
                                                                                                                   null, null, null, null, null) { }

        internal AnonymousObserverCollection(Action<T> actionAdded, Action<T> actionRemoved, Action actionClear) : this(null, actionClear, null, actionAdded, 
                                                                                                                        null, actionRemoved, null, null) { }

        internal AnonymousObserverCollection(Action<object, T> actionAdded, Action<object, T> actionRemoved, Action<object> actionClear) : this(null, null, null, null,
                                                                                                                                                actionClear, null, 
                                                                                                                                                actionAdded,
                                                                                                                                                actionRemoved) { }

        internal AnonymousObserverCollection(Action actionAddedWithoutParams, Action actionClearWithoutParams, Action actionRemovedWithoutParams,
                                             Action<T> actionAddedWithParams, Action<object> actionClearWithParams, Action<T> actionRemovedWithParams,
                                             Action<object, T> actionAddedWithParamsAndAnalitics, Action<object, T> actionRemovedWithParamsAndAnalitics)
        {
            m_actionAddedWithoutParams = actionAddedWithoutParams;
            m_actionAddedWithParams = actionAddedWithParams;
            m_actionAddedWithParamsAndAnalitics = actionAddedWithParamsAndAnalitics;

            m_actionClearWithoutParams = actionClearWithoutParams;
            m_actionClearWithParams = actionClearWithParams;

            m_actionRemovedWithoutParams = actionRemovedWithoutParams;
            m_actionRemovedWithParams = actionRemovedWithParams;
            m_actionRemovedWithParamsAndAnalitics = actionRemovedWithParamsAndAnalitics;
        }

        public void Dispose()
        {
            m_actionAddedWithoutParams = null;
            m_actionAddedWithParams = null;
            m_actionAddedWithParamsAndAnalitics = null;

            m_actionClearWithoutParams = null;
            m_actionClearWithParams = null;

            m_actionRemovedWithoutParams = null;
            m_actionRemovedWithParams = null;
            m_actionRemovedWithParamsAndAnalitics = null;
        }

        public void NotifyCollectionAdded(object sender, T newValue)
        {
            m_actionAddedWithoutParams?.Invoke();
            m_actionAddedWithParams?.Invoke(newValue);
            m_actionAddedWithParamsAndAnalitics?.Invoke(sender, newValue);
        }

        public void NotifyCollectionClear(object sender)
        {
            m_actionClearWithoutParams?.Invoke();
            m_actionClearWithParams?.Invoke(sender);
        }

        public void NotifyCollectionRemoved(object sender, T newValue)
        {
            m_actionRemovedWithoutParams?.Invoke();
            m_actionRemovedWithParams?.Invoke(newValue);
            m_actionRemovedWithParamsAndAnalitics?.Invoke(sender, newValue);
        }
    }
}
