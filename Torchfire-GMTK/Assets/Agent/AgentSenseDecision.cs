using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using myAgentFSM;

namespace AgentFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/SensePoi")]
    public class AgentSenseDecision : AgentDecision
    {
        public override bool Decide(AgentBaseStateMachine stateMachine)
        {
            var poiInLineOfSight = stateMachine.GetComponentInChildren<PointsOfInterest>();
            bool detectedobject = poiInLineOfSight.ClosestPoi();

            //pointOfInterest.poi = 
            return true;
        }
    }
}

