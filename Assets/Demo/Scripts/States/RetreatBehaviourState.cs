using UnityEngine;
using net.fiveotwo.fsm;

public class RetreatBehaviourState : State<Robot>
{
    [SerializeField]
    protected float moveSpeed;
    Vector3 spawnPosition;
    [Header("State Transitions")] 
    [AnimationStateName] 
    [SerializeField]
    protected string idleState;

    public override void Initialize()
    {
        spawnPosition = entity.GetInitialPosition();
    }

    public override void StateUpdate(Animator animator)
    {
        Vector3 position = spawnPosition - entity.transform.position;
        entity.transform.position += position * moveSpeed * Time.deltaTime;

        if (IsNearSpawnPoint()) {
            entity.SetState(idleState);
        }
    }

    public override void OnStateEnter(Animator animator)
    {
        entity.spriteRenderer.flipX = entity.transform.position.x > spawnPosition.x ? true : false;
    }

    public override void OnStateExit(Animator animator)
    {
        entity.ResetAllTransitionConditions();
    }

    public bool IsNearSpawnPoint()
    {
        return Vector2.Distance(spawnPosition, entity.transform.position) < 0.25f;
    }
}
