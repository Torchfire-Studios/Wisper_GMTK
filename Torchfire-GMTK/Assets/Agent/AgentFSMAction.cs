using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    public abstract class AgentFSMAction : MonoBehaviour
    {
        public abstract void Execute(AgentBaseStateMachine stateMachine);
        
    }
}

