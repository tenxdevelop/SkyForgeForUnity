/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace SkyForge.Extension
{
    public abstract class UIMenuPanelViewModel : IUIMenuPanelViewModel
    {
        public ReactiveProperty<bool> IsActive { get; private set; } = new();
        
        public abstract void Dispose();

        public abstract void Update(float deltaTime);

        public abstract void PhysicsUpdate(float deltaTime);
        
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