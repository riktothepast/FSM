using UnityEngine;

namespace FiveOTwoStudios.StateMachine
{
    public class MoveBehaviourState : BehaviourState
    {
        [SerializeField]
        protected float moveSpeed;
        protected Collectable collectable;

        void AssignCollectable()
        {
            collectable = FindObjectOfType<Collectable>();
            ((Robot)fsm).collectable = collectable;
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