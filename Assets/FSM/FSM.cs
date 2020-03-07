using UnityEngine;
namespace net.fiveotwo.fsm
{
    [RequireComponent(typeof(Animator))]
    public class FSM<E> : MonoBehaviour
    {
        protected Animator animator;
        protected State<E>[] states;
        protected string currentStateName;

        public void InitializeStates(E entity)
        {
            animator = GetComponent<Animator>();
            states = animator.GetBehaviours<State<E>>();
            foreach (State<E> state in states)
            {
                state.SetFSM(entity);
                state.Initialize();
            }
        }

        public void SetState(string stateName)
        {
            animator.Play(stateName);
            currentStateName = stateName;
        }

        public void ResetAllTransitionConditions()
        {
            foreach (AnimatorControllerParameter parameter in animator.parameters)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
}