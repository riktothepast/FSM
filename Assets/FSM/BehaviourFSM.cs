using UnityEngine;

namespace FiveOTwoStudios.StateMachine
{
    public class BehaviourFSM : MonoBehaviour
    {
        [SerializeField]
        protected UpdateType updateType;
        protected BehaviourState currentState;

        public void SetState(BehaviourState state)
        {
            currentState?.OnStateExit();
            currentState?.ReinitializeTransitions();
            currentState = state;
            currentState?.OnStateEnter();
        }

        public BehaviourState GetState()
        {
            return currentState;
        }

        public void UpdateFSM(float deltaTime)
        {
            if (currentState != null)
            {
                CheckStateTransitions(deltaTime);
                currentState.StateUpdate(deltaTime);
            }
        }

        void CheckStateTransitions(float deltaTime)
        {
            foreach (Transition transition in currentState.transitions)
            {
                if (transition.transitionEvent.Evaluate(deltaTime))
                {
                    SetState(transition.state);
                    break;
                }
            }
        }

        private void Update()
        {
            if (updateType.Equals(UpdateType.Update))
            {
                UpdateFSM(Time.deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (updateType.Equals(UpdateType.LateUpdate))
            {
                UpdateFSM(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (updateType.Equals(UpdateType.FixedUpdate))
            {
                UpdateFSM(Time.fixedDeltaTime);
            }
        }
    }
}