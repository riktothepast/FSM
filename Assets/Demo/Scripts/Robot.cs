using UnityEngine;

public class Robot : FSM<Robot>
{
    [SerializeField]
    public SpriteRenderer spriteRenderer;
    public Collectable collectable;
    private Vector2 initialPosition;

    private void Awake()
    {
        InitializeStates(this);
        initialPosition = transform.position;
    }

    public void ClearCurrentCollectable()
    {
        Destroy(collectable.gameObject);
    }

    public Vector2 GetInitialPosition()
    {
        return initialPosition;
    }
}
