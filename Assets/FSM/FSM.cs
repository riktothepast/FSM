using FiveOTwoStudios.StateMachine;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FSM<E> : MonoBehaviour
{
    protected Animator animator;

    public void InitializeStates(E entity) {
        animator = GetComponent<Animator>();
        State<E>[] states = animator.GetBehaviours<State<E>>();
        foreach (State<E> state in states)
        {
            state.SetFSM(entity);
            state.Initialize();
        }
    }

    public void ResetAllTransitionConditions() {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
    }
}
