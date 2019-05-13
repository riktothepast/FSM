using System;
using System.Collections.Generic;

namespace FiveOTwoStudios.StateMachine
{
    public class FSM<T>
    {
        protected State<T> currentState;

        public void SetState(State<T> state)
        {
            if (currentState != null)
            {
                currentState.OnStateExit();
            }
            currentState = state;
            currentState.OnStateEnter();
        }

        public void Update(float deltaTime)
        {
            if (currentState != null)
            {
                CheckStateTransitions();
                currentState.StateUpdate(deltaTime);
            }
        }

        void CheckStateTransitions()
        {
            foreach (KeyValuePair<Func<bool>, State<T>> transition in currentState.Transitions)
            {
                if (transition.Key())
                {
                    SetState(transition.Value);
                }
            }
        }
    }
}