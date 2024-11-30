/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Command
{
    public abstract class Service
    {
        protected ICommandProcessor m_commandProcessor;

        public Service(ICommandProcessor commandProcessor)
        {
            m_commandProcessor = commandProcessor;
        }

    }
}
