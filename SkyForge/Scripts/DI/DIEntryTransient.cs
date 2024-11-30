/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Infrastructure
{
    public class DIEntryTransient<T> : DIEntry<T> where T : IDisposable
    {
        public DIEntryTransient(DIContainer container, Func<DIContainer, T> factory) : base(container, factory) { }

        public override T CreateFactory()
        {
            return m_factory(m_container);
        }
    }
}
