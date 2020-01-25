using UnityEngine;
namespace FiveOTwoStudios.StateMachine
{
    public abstract class BehaviourSO<T> : ScriptableObject
    {
        public bool defaultState;
        [SerializeField]
        public Transition<T>[] transitions;
        [SerializeField]
        protected ScriptableObject[] soTransition;
        protected BehaviourFSM<T> fsm;
        protected T entity;

        protected virtual void Awake()
        {
            Debug.Log(transitions);
            foreach (Transition<T> trans in transitions)
            {
                trans.transitionEvent.Initialize(fsm, entity);
            }
        }

        protected void Start()
        {
            if (defaultState)
            {
                
            }
        }

        public void ReinitializeTransitions()
        {
            foreach (Transition<T> trans in transitions)
            {
                trans.transitionEvent.Reset();
            }
        }

        public abstract void StateUpdate(float deltaTime);

        public abstract void OnStateEnter();

        public abstract void OnStateExit();

    }
}