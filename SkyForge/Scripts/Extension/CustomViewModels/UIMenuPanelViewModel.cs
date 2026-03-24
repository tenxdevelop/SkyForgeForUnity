/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;

namespace SkyForge.Extension
{
    public abstract class UIMenuPanelViewModel : ViewModel, IUIMenuPanelViewModel
    {
        public ReactiveProperty<bool> IsActive { get; private set; } = new();
        
        public void ShowMenu()
        {
            IsActive.Value = true;
        }

        public void HideMenu()
        {
            IsActive.Value = false;
        }
    }
}