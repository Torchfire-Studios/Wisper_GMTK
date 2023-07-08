using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    [CreateAssetMenu(menuName = "FSM/Transition")]
    public sealed class AgentTransition : ScriptableObject
    {
        public AgentDecision Decision;
        public AgentBaseState TrueState;
        public AgentBaseState FalseState;

        public void Execute(AgentBaseStateMachine stateMachine)
        {
            if (Decision.Decide(stateMachine) && !(TrueState is AgentRemainInState))
                stateMachine.CurrentState = TrueState;
            else if (!(FalseState is AgentRemainInState))
                stateMachine.CurrentState = FalseState;
        }
    }
}


