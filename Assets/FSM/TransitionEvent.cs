using FiveOTwoStudios.StateMachine;
using UnityEngine;

public abstract class TransitionEvent : MonoBehaviour
{
    protected BehaviourFSM fsm;
    protected ScriptableObject configuration;
    public abstract bool Evaluate(float deltaTime);
    public virtual void Initialize(BehaviourFSM fsm)
    {
        this.fsm = fsm;
    }
    public virtual void Reset(ScriptableObject configuration)
    {
        this.configuration = configuration;
    }
}
