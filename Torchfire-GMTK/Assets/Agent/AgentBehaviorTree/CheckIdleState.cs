using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIdleState : Node
{
    private AgentState _agentState;

    public CheckIdleState(AgentState agentState)
    {
        _agentState = agentState;
    }

    public override NodeState Evaluate()
    {
        
        if (AgentBT.agentState == AgentState.IDLE)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            state = NodeState.FAILURE;
            return state;
        }
    }
}
