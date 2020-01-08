using UnityEngine;

namespace FiveOTwoStudios.StateMachine
{
    public class RetreatBehaviourState : BehaviourState
    {
        [SerializeField]
        protected float moveSpeed;
        Vector3 spawnPosition;

        public override void Awake()
        {
            base.Awake();

            spawnPosition = transform.position;
        }

        public override void OnStateEnter()
        {
            ReinitializeTransitions();
        }

        public override void OnStateExit()
        {

        }

        public override void StateUpdate(float deltaTime)
        {
            Vector3 position = spawnPosition - transform.position;
            transform.position += position * moveSpeed * deltaTime;
        }
    }
}