/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.Events;
using SkyForge.Extension;
using SkyForge.Reactive;
using UnityEngine;

namespace SkyForge.MVVM.Binders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_REACTIVE_COLLECTION_BINDER +
                      "UIScreenView to unity event binder")]
    public class UIScreenViewCollectionToUnityEventBinder : ObservableBinder<UIScreenView>
    {
        
        [SerializeField] private UnityEvent<UIScreenView> _eventAdded;
        [SerializeField] private UnityEvent<UIScreenView> _eventRemoved;
        [SerializeField] private UnityEvent _eventCleared;
        protected override void OnPropertyChanged(object sender, UIScreenView newValue)
        {
            
        }

        protected override IBinding BindInternal(IViewModel viewModel)
        {
            return BindCollection(PropertyName, viewModel, OnAdded, OnRemoved, OnCleared);
        }

        private void OnAdded(UIScreenView view)
        {
            _eventAdded?.Invoke(view);
        }

        private void OnRemoved(UIScreenView view)
        {
            _eventRemoved?.Invoke(view);
        }

        private void OnCleared()
        {
            _eventCleared?.Invoke();   
        }
    }
}