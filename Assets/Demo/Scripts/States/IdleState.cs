using FiveOTwoStudios.StateMachine;
using UnityEngine;

public class IdleState : State<Robot>
{
    public override void OnStateEnter(Animator animator)
    {
        
    }

    public override void OnStateExit(Animator animator)
    {
        entity.ResetAllTransitionConditions();
    }

    public override void StateUpdate(Animator animator)
    {
        animator.SetBool("isMoving", FindObjectOfType<Collectable>() != null);
    }
}
