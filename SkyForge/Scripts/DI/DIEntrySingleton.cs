/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Infrastructure
{
    public class DIEntrySingleton<T> : DIEntry<T> where T : IDisposable
    {
        private T m_instance;
        public DIEntrySingleton(DIContainer container, Func<DIContainer, T> factory) : base(container, factory) { }

        public override T CreateFactory()
        {
            if (m_instance is null)
                m_instance = m_factory(m_container);

            return m_instance;
        }

        protected override void Disposed()
        {
            m_instance?.Dispose();
            base.Disposed();
        }

    }
}
