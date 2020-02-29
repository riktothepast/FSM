using FiveOTwoStudios.StateMachine;
using UnityEngine;

public class Returned : TransitionEvent
{
    Robot robo;
    Vector3 spawnPosition;

    public override void Initialize(BehaviourFSM fsm)
    {
        base.Initialize(fsm);
        robo = (Robot)fsm;
        spawnPosition = robo.transform.position;
    }

    public override bool Evaluate(float deltaTime)
    {
        return Vector2.Distance(spawnPosition, robo.transform.position) < 0.25f;
    }
}
