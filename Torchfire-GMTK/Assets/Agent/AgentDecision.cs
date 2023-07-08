using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    public abstract class AgentDecision : ScriptableObject
    {
        public abstract bool Decide(AgentBaseStateMachine state);
    }
}

