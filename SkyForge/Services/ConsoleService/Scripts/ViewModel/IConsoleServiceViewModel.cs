/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.MVVM;

namespace SkyForge.Services.ConsoleService
{
    public interface IConsoleServiceViewModel : IViewModel
    {
        ReactiveProperty<bool> IsShowConsole { get; }
        
        ReactiveProperty<Message> MessageProperty { get; }
        
        void ProcessCommand(object sender, string command);
        
    }
}
