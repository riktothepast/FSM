using FiveOTwoStudios.StateMachine;
using UnityEngine;

public class RetreatState : State<Robot>
{
    public RetreatState(Robot entity) : base(entity) { }

    public override void OnStateEnter()
    {
        entity.collectable.transform.SetParent(entity.transform);
        entity.direction = entity.GetDirectionToSpawnPoint();
        entity.spriteRenderer.flipX = entity.direction.x < 0;
        entity.animator.Play("Moving");
    }

    public override void OnStateExit()
    {
        entity.ClearCurrentCollectable();
    }

    public override void StateUpdate(float deltaTime)
    {
        entity.velocity = entity.direction * deltaTime;
        entity.transform.position += (Vector3)entity.velocity;
    }
}
