using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    public class AgentBaseStateMachine : MonoBehaviour
    {
        [SerializeField] private AgentBaseState _initialState;

        private void Awake()
        {
            CurrentState = _initialState;
        }

        public AgentBaseState CurrentState {get; set; }

        private void Update()
        {
            CurrentState.Execute(this);
        }
    }
}

