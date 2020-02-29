using FiveOTwoStudios.StateMachine;
using UnityEngine;

public class Collected : TransitionEvent
{
    Robot robo;

    public override void Initialize(BehaviourFSM fsm)
    {
        base.Initialize(fsm);
        robo = (Robot)fsm;
    }

    public override bool Evaluate(float deltaTime)
    {
        if (!robo.collectable)
        {
            return false;
        }

        return Vector2.Distance(fsm.transform.position, robo.collectable.transform.position) < 0.25f;
    }
}
