using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

public class AgentBT : Tree
{
    /*KNOWLEDGE BASE*/
    public UnityEngine.Transform destination;
    public static float fovRange = 6f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new TaskWander(transform),
                new TaskScout(transform)
            }),
            
        });
        return root;
    }
}
