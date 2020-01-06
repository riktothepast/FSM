using FiveOTwoStudios.StateMachine;
using UnityEngine;

public class Robot : BehaviourFSM
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Collectable collectable;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ClearCurrentCollectable()
    {
        Destroy(collectable.gameObject);
    }
}
