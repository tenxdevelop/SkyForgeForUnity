/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;

namespace SkyForge.FSM.Infrastructure
{
    internal class StateNode
    {
        public IState State { get; private set; }

        public HashSet<ITransition> Transitions { get; private set; }

        public StateNode(IState state)
        {
            State = state;
            Transitions = new HashSet<ITransition>();
        }

        public void AddTransition(IState targetState, IPredicate condition)
        {
            Transitions.Add(new Transition(targetState, condition));
        }
    }
}
