using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class ActionMove : Node
{
    //private static int _enemyLayerMask = 1 << 6;
    private Transform _transform; //agent's transform
    //private Animation _anim;
    //private AgentState _agentState;
    //private AgentState _prevAgentState;
    private NavMeshAgent _navMeshAgent;
    

    public ActionMove(Transform transform/*, Animator anim, AgentState agentState*/)
    {
        _transform = transform;
        _navMeshAgent = transform.GetComponent<NavMeshAgent>();
        //_anim = anim;
        //_agentState = agentState;
    }

    public override NodeState Evaluate()
    {
        //go to destination
        Debug.Log(_navMeshAgent.destination +"  "+ AgentBT.destination);
        _navMeshAgent.destination = AgentBT.destination;
        //If the agent is near it's destination
        //make new state, set destination to default and return success
        if (Vector3.Distance(_transform.position, AgentBT.destination) < 0.1f)
        {
            AgentBT.agentState = AgentState.INVESTIGATE;
            AgentBT.destination = _transform.position;
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.RUNNING;
        return state;
    }
}
