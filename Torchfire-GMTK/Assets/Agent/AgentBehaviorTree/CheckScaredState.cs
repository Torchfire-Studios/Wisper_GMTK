using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckScaredState : Node
{
    private AgentState _agentState;

    public CheckScaredState(AgentState agentState)
    {
        _agentState = agentState;
    }

    public override NodeState Evaluate()
    {
        
        if (_agentState == AgentState.SCARED)
        {
            Debug.Log("Scared");
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
