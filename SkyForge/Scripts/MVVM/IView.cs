/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.MVVM
{
    public interface IView
    {
        string ViewModelTypeFullName { get; }

        string ViewModelPropertyName { get; }

        void Bind(IViewModel viewModel);

#if UNITY_EDITOR
        bool IsValidSetup();

        void Fix();
#endif
    }
}
