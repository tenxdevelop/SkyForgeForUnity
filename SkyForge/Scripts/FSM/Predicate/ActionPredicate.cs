/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.FSM
{
    public class ActionPredicate : IPredicate
    {
        private Action m_action;

        public ActionPredicate(Action action)
        {
            m_action = action;
        }

        public bool Evaluate()
        {
            m_action?.Invoke();
            return true;
        }
    }
}
