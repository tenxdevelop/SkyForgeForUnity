/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using System;

namespace SkyForge.MVVM.NetworkBinders
{
    public abstract class ObservableNetworkBinder : NetworkBinder
    {
        public abstract Type ArgumentType { get; }
    }
    
    public abstract class ObservableNetworkBinder<T> : ObservableNetworkBinder
    {
        public override Type ArgumentType => typeof(T);
        protected abstract void OnPropertyChanged(object sender, T newValue);
        
        protected override IBinding BindInternal(INetworkViewModel viewModel)
        {
            return BindObservable(PropertyName, viewModel, OnPropertyChanged);
        }

        protected IBinding BindObservable(string propertyName, INetworkViewModel viewModel, Action<T> callback)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var observable = propertyInfo.GetValue(viewModel) as Reactive.IObservable<T>;
            var handle = observable.Subscribe(callback);
            return handle;
        }

        protected IBinding BindObservable(string propertyName, INetworkViewModel viewModel, Action<object, T> callback)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var observable = propertyInfo.GetValue(viewModel) as Reactive.IObservable<T>;
            var handle = observable.Subscribe(callback);
            return handle;
        }

        protected IBinding BindCollection(string propertyName, INetworkViewModel viewModel, Action<T> actionAdded, Action<T> actionRemoved, Action actionClear)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var observable = propertyInfo.GetValue(viewModel) as IObservableCollection<T>;
            var handle = observable.Subscribe(actionAdded, actionRemoved, actionClear);
            return handle;
        }

        protected IBinding BindCollection(string propertyName, INetworkViewModel viewModel, Action<object, T> actionAdded, Action<object, T> actionRemoved, Action<object> actionClear)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var observable = propertyInfo.GetValue(viewModel) as IObservableCollection<T>;
            var handle = observable.Subscribe(actionAdded, actionRemoved, actionClear);
            return handle;
        }
    }
}