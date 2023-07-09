using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

public enum AgentState
{
    LURED,
    SCARED,
    IDLE
}

public class AgentBT : Tree
{
    /*KNOWLEDGE BASE*/
    public static UnityEngine.Vector3 destination;
    public static float fovRange = 2f;
    public static AgentState agentState = AgentState.IDLE;
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
                //"check investigate Status"
                new ActionScout(transform),
                new ActionInvestigate(transform),
                //new ActionInteract(transform),
                new ActionMove(transform /*anim*/),
            }),
            //"Idle Status"
            new Sequence(new List<Node>
            {
                new CheckIdleState(agentState),
                //new ActionInteract(transform),
                //chek if have target
                new ActionMove(transform /*anim*/),
            }),
        });
        UnityEngine.Debug.Log(root);
        return root;
    }
}
