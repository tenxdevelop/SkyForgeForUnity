/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.FSM
{
    public class FuncPredicate : IPredicate
    {
        private Func<bool> m_func;

        public FuncPredicate(Func<bool> func)
        {
            m_func = func;
        }

        public bool Evaluate() => m_func?.Invoke() ?? false;
    }
}
