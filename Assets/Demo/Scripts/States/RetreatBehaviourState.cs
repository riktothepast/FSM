using UnityEngine;

namespace FiveOTwoStudios.StateMachine
{
    public class RetreatBehaviourState : BehaviourState<Robot>
    {
        [SerializeField]
        protected float moveSpeed;
        Vector3 spawnPosition;
        [SerializeField]
        Transition<Robot>[] trans;

        protected override void Awake()
        {
            base.Awake();
            spawnPosition = transform.position;
        }

        public override void OnStateEnter()
        {
            ReinitializeTransitions();
            entity.spriteRenderer.flipX = transform.position.x > spawnPosition.x ? true : false;
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