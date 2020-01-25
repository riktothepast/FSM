using FiveOTwoStudios.StateMachine;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transition/Returned")]
public class Returned : TransitionEvent<Robot>
{
    Robot robo;
    Vector3 spawnPosition;

    public override void Initialize(BehaviourFSM<Robot> fsm, Robot robot)
    {
        base.Initialize(fsm, robot);
        robo = (Robot)fsm;
        spawnPosition = robo.transform.position;
    }

    public override bool Evaluate(float deltaTime)
    {
        return Vector2.Distance(spawnPosition, robo.transform.position) < 0.25f;
    }
}
