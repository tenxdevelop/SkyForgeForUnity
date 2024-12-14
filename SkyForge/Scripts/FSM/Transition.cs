/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.FSM
{
    public class Transition : ITransition
    {
        public IState TargetState { get; private set; }

        public IPredicate Condition { get; private set; }

        public Transition(IState targetState, IPredicate condition)
        {
            TargetState = targetState;
            Condition = condition;
        }
    }
}
