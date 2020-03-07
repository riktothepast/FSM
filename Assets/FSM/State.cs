using UnityEngine;
namespace net.fiveotwo.fsm
{
    public abstract class State<E> : StateMachineBehaviour
    {
        protected E entity;

        public void SetFSM(E entity) {
            this.entity = entity;
        }

        public virtual void Initialize() { }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
              OnStateEnter(animator);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            OnStateExit(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            StateUpdate(animator);
        }

        public abstract void StateUpdate(Animator animator);

        public abstract void OnStateEnter(Animator animator);

        public abstract void OnStateExit(Animator animator);

    }
}