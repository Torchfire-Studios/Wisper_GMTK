using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    public sealed class AgentState : MonoBehaviour
    {
        [CreateAssetMenu(menuName = "FSM/State")]
        public sealed class State : BaseState
        {
            public List<AgentFSMAction> Action = new List<FSMAction>();
            public List<AgentTransition> Transitions = new List<Transition>();

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

