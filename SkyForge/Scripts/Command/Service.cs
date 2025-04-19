/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Command
{
    public abstract class Service : IDisposable
    {
        protected ICommandProcessor m_commandProcessor;

        public Service(ICommandProcessor commandProcessor)
        {
            m_commandProcessor = commandProcessor;
        }

        public abstract void Dispose();
    }
}
