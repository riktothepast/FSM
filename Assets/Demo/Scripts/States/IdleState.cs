using FiveOTwoStudios.StateMachine;
using UnityEngine;

public class IdleState : State<Robot>
{
    public IdleState(Robot entity) : base(entity) { }

    public override void OnStateEnter()
    {
        entity.animator.Play("Idle");
    }

    public override void OnStateExit()
    {

    }

    public override void StateUpdate(float deltaTime)
    {

    }
}
