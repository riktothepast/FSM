using FiveOTwoStudios.StateMachine;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    public float moveSpeed { get; set; }
    public Vector2 velocity { get; set; }
    public Vector2 direction { get; set; }
    public Vector2 spawnPoint { get; set; }
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Collectable collectable;
    FSM<Robot> stateMachine;
    MoveState moveState;
    RetreatState retreatState;
    IdleState idleState;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        stateMachine = new FSM<Robot>();
        moveSpeed = speed;
        moveState = new MoveState(this);
        retreatState = new RetreatState(this);
        idleState = new IdleState(this);
        moveState.AddTransition(IsNearCollectablePoint, retreatState);
        retreatState.AddTransition(IsNearSpawnPoint, idleState);
        idleState.AddTransition(AreCollactablesAvailable, moveState);
    }

    private void Start()
    {
        stateMachine.SetState(idleState);
    }

    void Update()
    {
        stateMachine.Update(Time.deltaTime);
    }

    public void ClearCurrentCollectable()
    {
        Destroy(collectable.gameObject);
    }

    public Vector2 GetDirectionToCollectable()
    {
        return collectable.transform.position - transform.position;
    }

    public Vector2 GetDirectionToSpawnPoint()
    {
        return spawnPoint - (Vector2)transform.position;
    }

    bool AreCollactablesAvailable()
    {
        collectable = FindObjectOfType<Collectable>();
        return collectable != null;
    }

    bool IsNearCollectablePoint()
    {
        return Vector2.Distance(transform.position, collectable.transform.position) < 0.25f;
    }

    bool IsNearSpawnPoint()
    {
        return Vector2.Distance(transform.position, spawnPoint) < 0.25f;
    }
}
