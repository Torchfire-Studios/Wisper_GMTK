using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AgentFSM;
using System.Collections.Specialized;
//using System.Diagnostics;

namespace myAgentFSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
    public class AgentPatrolAction : AgentFSMAction
    {
        public override void Execute(AgentBaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            var randomPointOnNavMesh = stateMachine.GetComponent<RandomPointOnNavMesh>();
            Vector3 point;

            if(randomPointOnNavMesh.RandomPoint(stateMachine.transform.position, 2f, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            }
            //navMeshAgent.setDestination()
        }
    }
}

