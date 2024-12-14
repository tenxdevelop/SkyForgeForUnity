/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.FSM
{
    public interface ITransition
    {
        IState TargetState { get; }
        IPredicate Condition { get; }
    }
}
