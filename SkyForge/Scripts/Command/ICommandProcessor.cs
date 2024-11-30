/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Command
{
    public interface ICommandProcessor : IDisposable
    {
        void RegisterCommandHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;

        bool Process<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
