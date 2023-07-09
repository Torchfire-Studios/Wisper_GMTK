using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using AgentFSM;

namespace myAgentFSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Wander")]
    public class AgentWanderAction : AgentFSMAction
    {
        public bool hasPoint = false;
        public override void Execute(AgentBaseStateMachine stateMachine)
        {
            //get necessary components
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            var randomPointOnNavMesh = stateMachine.GetComponent<RandomPointOnNavMesh>();
            Vector3 point = navMeshAgent.destination;


            
            if (!hasPoint && randomPointOnNavMesh.RandomPoint(stateMachine.transform.position, 4f, out point))
            {
                hasPoint = true;
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                navMeshAgent.destination = point;
            }

            if (Vector3.Distance(stateMachine.transform.position, point) < 0.5f)
            {
                hasPoint = false;
            }







            //if at "go to"
            //sense
            //if sensed
            //transition
            //else
            //reset "go to" point 
        }
    }
}

