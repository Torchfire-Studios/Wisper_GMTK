using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/SenseEnv")]
    public class AgentSenseDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var enemyInLineOfSight = stateMachine.GetComponent<EnemySightSensor>();
            return enemyInLineOfSight.Ping();
        }
    }
}

