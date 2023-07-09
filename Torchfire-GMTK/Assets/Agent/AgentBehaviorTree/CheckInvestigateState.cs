using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckInvestigateState : Node
{
    private AgentState _agentState;

    public CheckInvestigateState(AgentState agentState)
    {
        //_agentState = agentState;
    }

    public override NodeState Evaluate()
    {

        if (AgentBT.agentState == AgentState.INVESTIGATE)
        {
            Debug.Log("investigate");
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
