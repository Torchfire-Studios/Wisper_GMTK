using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskScout : Node
{
    private static int _enemyLayerMask = 1 << 6;
    private Transform _transform; //agent's transform
    public TaskScout(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        
        object t = GetData("target");
        if(t == null)
        {
            
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, AgentBT.fovRange, _enemyLayerMask);

            
            if (colliders.Length > 0)
            {
                Debug.Log("Scouting");

                parent.parent.SetData("target", colliders[0].transform);
                //_animator.SetBool()
                state = NodeState.SUCCESS;
                return state;
            }
            state = NodeState.FAILURE;
            return state;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
