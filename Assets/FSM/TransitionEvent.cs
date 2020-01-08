using UnityEngine;

namespace FiveOTwoStudios.StateMachine
{
    public abstract class TransitionEvent : ScriptableObject
    {
        protected BehaviourFSM fsm;

        public abstract bool Evaluate();
        public virtual void Initialize(BehaviourFSM fsm) { this.fsm = fsm; }
        public virtual void Reset() { }
    }
}