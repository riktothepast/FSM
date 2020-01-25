using UnityEngine;

namespace FiveOTwoStudios.StateMachine
{
    public abstract class TransitionEvent<T> : ScriptableObject
    {
        protected BehaviourFSM<T> fsm;
        protected T entity;

        public abstract bool Evaluate(float deltaTime);
        public virtual void Initialize(BehaviourFSM<T> fsm, T entity) {
            this.fsm = fsm;
            this.entity = entity;
        }
        public virtual void Reset() { }
    }
}