using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    public class AgentDecision : ScriptableObject
    {
        public abstract bool Decide(AgentBaseStateMachine state);
    }
}

