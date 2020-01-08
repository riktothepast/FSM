using UnityEngine;

namespace FiveOTwoStudios.StateMachine
{
    public class MoveBehaviourState : BehaviourState
    {
        [SerializeField]
        protected float moveSpeed;
        protected Collectable collectable;
        Robot robot;

        protected override void Awake()
        {
            base.Awake();
            robot = (Robot)fsm;
        }

        void AssignCollectable()
        {
            collectable = FindObjectOfType<Collectable>();
            if (collectable)
            {
                robot.collectable = collectable;
                robot.spriteRenderer.flipX = transform.position.x > collectable.transform.position.x ? true : false;
            }
        }

        public override void OnStateEnter()
        {
            ReinitializeTransitions();
            AssignCollectable();
        }

        public override void OnStateExit()
        {
            Destroy(collectable.gameObject);
            collectable = null;
        }

        public override void StateUpdate(float deltaTime)
        {
            if (!collectable)
            {
                return;
            }
            Vector3 position = collectable.transform.position - transform.position;
            transform.position += position * moveSpeed * deltaTime;
        }
    }
}