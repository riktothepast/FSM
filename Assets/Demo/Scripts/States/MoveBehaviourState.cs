using net.fiveotwo.fsm;
using UnityEngine;

public class MoveBehaviourState : State<Robot>
{
    [SerializeField]
    protected float moveSpeed;
    protected Collectable collectable;
    [Header("State Transitions")]
    [AnimationStateName]
    [SerializeField]
    protected string retratingState;

    void AssignCollectable()
    {
        collectable = FindObjectOfType<Collectable>();
        if (collectable)
        {
            entity.collectable = collectable;
            entity.spriteRenderer.flipX = entity.transform.position.x > collectable.transform.position.x ? true : false;
        }
    }

    public override void Initialize()
    {
        entity.collectable = null;
    }

    public override void StateUpdate(Animator animator)
    {
        if (!collectable)
        {
            return;
        }
        Vector3 position = collectable.transform.position - entity.transform.position;
        entity.transform.position += position * moveSpeed * Time.deltaTime;
        if (IsNearCollectable()) {
            entity.SetState(retratingState);
        }
    }

    public override void OnStateEnter(Animator animator)
    {
        AssignCollectable();
    }

    public override void OnStateExit(Animator animator)
    {
        Destroy(collectable.gameObject);
        collectable = null;

        entity.ResetAllTransitionConditions();
    }

    public bool IsNearCollectable()
    {
        if (!collectable)
        {
            return false;
        }
        return Vector2.Distance(collectable.transform.position, entity.transform.position) < 0.25f;
    }
}