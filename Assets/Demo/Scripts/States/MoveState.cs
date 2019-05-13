using FiveOTwoStudios.StateMachine;
using UnityEngine;

public class MoveState : State<Robot>
{
    public MoveState(Robot entity) : base(entity) { }

    public override void OnStateEnter()
    {
        entity.direction = entity.GetDirectionToCollectable();
        entity.spriteRenderer.flipX = entity.direction.x < 0;
        entity.animator.Play("Moving");
    }

    public override void OnStateExit()
    {

    }

    public override void StateUpdate(float deltaTime)
    {
        entity.velocity = entity.direction * deltaTime;
        entity.transform.position += (Vector3)entity.velocity;
    }
}
