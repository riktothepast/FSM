using System;

namespace FiveOTwoStudios.StateMachine
{
    [Serializable]
    public class Transition
    {
        public TransitionEvent transitionEvent;
        public BehaviourState state;
    }
}