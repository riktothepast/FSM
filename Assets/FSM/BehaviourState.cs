using UnityEngine;
namespace FiveOTwoStudios.StateMachine
{
    [RequireComponent(typeof(BehaviourFSM))]
    public abstract class BehaviourState : MonoBehaviour
    {
        public bool defaultState;
        public Transition[] transitions;

        protected BehaviourFSM fsm;
        protected virtual void Awake()
        {
            fsm = GetComponent<BehaviourFSM>();
            foreach (Transition trans in transitions)
            {
                trans.transitionEvent.Initialize(fsm);
            }
        }

        protected void Start()
        {
            if (defaultState)
            {
                fsm.SetState(this);
            }
        }

        public void ReinitializeTransitions()
        {
            foreach (Transition trans in transitions)
            {
                trans.transitionEvent.Reset();
            }
        }

        public abstract void StateUpdate(float deltaTime);

        public abstract void OnStateEnter();

        public abstract void OnStateExit();
    }
}