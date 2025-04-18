/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.FSM.Infrastructure;
using System.Collections.Generic;
using System;

namespace SkyForge.FSM
{
    public class FinalStateMachine : IFinalStateMachine
    {
        private StateNode m_currentState;
        
        private Dictionary<Type, StateNode> m_states = new ();
        private HashSet<ITransition> m_anyTransitions = new ();
        public void AddTransition<TState>(IState targetState, IPredicate condition) where TState : IState
        {
            var stateType = typeof(TState);

            RegisterState(targetState);

            if (m_states.TryGetValue(stateType, out var stateNode))
            {
                stateNode.AddTransition(targetState, condition);
            }
        }

        public void AddAnyTransition(IState targetState, IPredicate condition)
        {
            RegisterState(targetState);
            m_anyTransitions.Add(new Transition(targetState, condition));
        }

        public void RegisterState(IState state)
        {
            var stateType = state.GetType();
            if (m_states.ContainsKey(stateType))
                return;

            m_states[stateType] = new StateNode(state);
        }

        public void PhysicsUpdate(float deltaTime)
        {
            m_currentState?.State.OnPhysicsUpdate(deltaTime);
        }

        public void Update(float deltaTime)
        {
            var transition = CheckTransition();

            if (transition != null)
            {
                ChangeState(transition.TargetState);
            }

            m_currentState?.State.OnUpdate(deltaTime);
        }

        public void SetState(IState state)
        {
            var stateType = state.GetType();
            m_currentState = m_states[stateType];
        }

        private void ChangeState(IState state)
        {
            if (state == m_currentState?.State)
                return;

            var stateType = state.GetType();
            var nextState = m_states[stateType];

            m_currentState?.State?.OnExit();
            nextState.State.OnStart();

            m_currentState = nextState;
        }

        private ITransition CheckTransition()
        {
            foreach (var anyTransition in m_anyTransitions)
            {
                if(anyTransition.Condition.Evaluate())
                    return anyTransition;
            }

            foreach (var transition in m_currentState?.Transitions)
            {
                if(transition.Condition.Evaluate())
                    return transition;
            }

            return null;
        }

    }
}
