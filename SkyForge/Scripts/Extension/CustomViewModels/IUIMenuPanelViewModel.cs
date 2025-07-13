/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;

namespace SkyForge.Extension
{
   public interface IUIMenuPanelViewModel : IViewModel
   {
      ReactiveProperty<bool> IsActive { get; }

      void ShowMenu();

      void HideMenu();
   }
}