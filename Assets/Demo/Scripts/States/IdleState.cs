using net.fiveotwo.fsm;
using UnityEngine;

public class IdleState : State<Robot>
{
    [Header("State Transitions")]
    [AnimationStateName]
    [SerializeField]
    protected string movingState;

    public override void OnStateEnter(Animator animator)
    {
        
    }

    public override void OnStateExit(Animator animator)
    {
        entity.ResetAllTransitionConditions();
    }

    public override void StateUpdate(Animator animator)
    {
        if (FindObjectOfType<Collectable>() != null)
        {
            entity.SetState(movingState);
        }
    }
}
