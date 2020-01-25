using System;

namespace FiveOTwoStudios.StateMachine
{
    [Serializable]
    public class Transition<T>
    {
        public TransitionEvent<T> transitionEvent;
        public BehaviourState<T> state;
    }
}