using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public sealed class AgentState : AgentBaseState
    {
        public List<AgentFSMAction> Action = new List<AgentFSMAction>();
        public List<AgentTransition> Transitions = new List<AgentTransition>();

        public override void Execute(AgentBaseStateMachine machine)
        {
            foreach(var action in Action)
                action.Execute(machine);

            foreach(var transition in Transitions)
                transition.Execute(machine);
        }
    }
}

