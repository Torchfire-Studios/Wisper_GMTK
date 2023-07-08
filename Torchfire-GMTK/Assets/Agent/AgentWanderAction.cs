using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myAgentFSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Wander")]
    public class AgentWanderAction : MonoBehaviour
    {
        bool hasPoint;
        public override void Execute(AgentBaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            var randomPointOnNavMesh = stateMachine.GetComponent<RandomPointOnNavMesh>();
            Vector3 point;
            


            if (!hasPoint && randomPointOnNavMesh.RandomPoint(stateMachine.transform.position, 4f, out point))
            {
                hasPoint = true;
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                navMeshAgent.destination = point;
            }

            //if "go to" point does not exist
                //Create new "go to" point
            //Go to "go to" point
            //if at "go to"
                //sense
                //if sensed
                    //transition
               //else
                    //reset "go to" point 
        }
    }
}

