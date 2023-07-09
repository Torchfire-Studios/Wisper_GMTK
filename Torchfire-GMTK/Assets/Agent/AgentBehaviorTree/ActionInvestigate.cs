using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class ActionInvestigate : Node
{
    private Transform _transform;
    private NavMeshAgent _navMeshAgent;

    public ActionInvestigate(Transform transform)
    {
        _transform = transform;
        _navMeshAgent = transform.GetComponent<NavMeshAgent>();
    }

    /*
     * This action will tell the agent to move towards the POINT OF INTEREST
     */
    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            Debug.Log("Walking to target");
            _navMeshAgent.destination = target.position;

        }

        state = NodeState.RUNNING;
        return state;
    }
}
