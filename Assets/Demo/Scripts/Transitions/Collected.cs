using FiveOTwoStudios.StateMachine;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transition/Collected")]
public class Collected : TransitionEvent<Robot>
{
    Robot robo;

    public override void Initialize(BehaviourFSM<Robot> fsm, Robot entity)
    {
        base.Initialize(fsm, entity);
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
