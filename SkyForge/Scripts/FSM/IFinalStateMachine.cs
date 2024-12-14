/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.FSM
{
    public interface IFinalStateMachine
    {
        void SetState(IState state);
        void Update(float deltaTime);
        void PhysicsUpdate(float deltaTime);
        void RegisterState(IState state);
        void AddTransition<TState>(IState targetState, IPredicate condition) where TState : IState;
        void AddAnyTransition(IState targetState, IPredicate condition);
    }
}
