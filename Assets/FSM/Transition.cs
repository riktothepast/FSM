using System;
using UnityEngine;

namespace FiveOTwoStudios.StateMachine
{
    [Serializable]
    public class Transition
    {
        public TransitionEvent transitionEvent;
        public ScriptableObject transitionConfiguration;
        public BehaviourState state;
    }
}