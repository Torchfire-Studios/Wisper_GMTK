using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckLuredState : Node
{
    private AgentState _agentState;

    public CheckLuredState(AgentState agentState)
    {
        _agentState = agentState;
    }

    public override NodeState Evaluate()
    {
        
        if (_agentState == AgentState.LURED)
        {
            Debug.Log("Lured");
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
