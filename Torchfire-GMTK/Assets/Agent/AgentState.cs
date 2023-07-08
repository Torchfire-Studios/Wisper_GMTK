using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    public sealed class AgentState : MonoBehaviour
    {
        [CreateAssetMenu(menuName = "FSM/State")]
        public sealed class State : AgentBaseState
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
}

