using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

public enum AgentState
{
    LURED,
    SCARED,
    IDLE,
    INVESTIGATE
}

public class AgentBT : Tree
{
    /*KNOWLEDGE BASE*/
    public static UnityEngine.Vector3 destination;
    public static float fovRange = 2f;
    public static float interactRange = 0.5f;
    public static AgentState agentState = AgentState.INVESTIGATE;
    //public Vector3 target; 

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            //"Scared Status"
            new Sequence(new List<Node>
            {
                new CheckScaredState(agentState),
                //do scared things
                new ActionMove(transform /*anim*/),
            }),
            //"Lured Status"
            new Sequence(new List<Node>
            {
                new CheckLuredState(agentState),
                //  do lure things
                new ActionMove(transform /*anim*/),
            }),
            //"Investigate Status"
            new Sequence(new List<Node>
            {
                new CheckInvestigateState(agentState),
                new ActionScout(transform),// if have target find target
                new ActionMove(transform /*anim*/),
            }),
            //"Idle Status"
            new Sequence(new List<Node>
            {
                new CheckIdleState(agentState),
                new ActionMove(transform /*anim*/),

            }),

        });
        return root;
    }
}
