using FiveOTwoStudios.StateMachine;
using UnityEngine;

public class Robot : BehaviourFSM
{
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    public Collectable collectable;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ClearCurrentCollectable()
    {
        Destroy(collectable.gameObject);
    }
}
