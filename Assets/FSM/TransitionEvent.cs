using FiveOTwoStudios.StateMachine;
using UnityEngine;

public abstract class TransitionEvent : MonoBehaviour
{
    protected BehaviourFSM fsm;

    public abstract bool Evaluate();
    public virtual void Initialize(BehaviourFSM fsm) { this.fsm = fsm; }
    public virtual void Reset() { }
}
