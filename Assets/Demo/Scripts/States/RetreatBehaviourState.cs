using UnityEngine;

namespace FiveOTwoStudios.StateMachine
{
    public class RetreatBehaviourState : BehaviourState
    {
        [SerializeField]
        protected float moveSpeed;
        Vector3 spawnPosition;
        Robot robot;

        protected override void Awake()
        {
            base.Awake();
            robot = (Robot)fsm;
            spawnPosition = transform.position;
        }

        public override void OnStateEnter()
        {
            ReinitializeTransitions();
            robot.spriteRenderer.flipX = transform.position.x > spawnPosition.x ? true : false;
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