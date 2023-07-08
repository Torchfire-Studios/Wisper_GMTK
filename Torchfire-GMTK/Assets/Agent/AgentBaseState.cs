using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    public class AgentBaseState : ScriptableObject
    {
        public virtual void Execute(AgentBaseStateMachine machine) { }
    }
}

