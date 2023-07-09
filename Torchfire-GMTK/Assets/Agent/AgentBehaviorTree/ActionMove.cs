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
        if(AgentBT.destination == null)
        {
            //_navMeshAgent.destination = AgentBT.target;
            Debug.Log("No Target");
        }

        _navMeshAgent.destination = AgentBT.destination;
        //if agent state changed? IDLE -> Scared
        if (Vector3.Distance(_transform.position, AgentBT.destination) < 0.05f)
        {
            AgentBT.agentState = AgentState.IDLE;
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.RUNNING;
        return state;
    }
}
