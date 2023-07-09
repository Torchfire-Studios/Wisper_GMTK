using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskWander : Node
{
    private Transform _transform; //agent's transform
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private bool hasPoint;
    private Vector3 point;
    //private bool hasPoint; //to stop re-selecting a destination
    // Start is called before the first frame update

    public TaskWander(Transform transform)
    {
        _transform = transform;
        _navMeshAgent = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        point = transform.position;
    }

    public override NodeState Evaluate()
    {
        if (!hasPoint && RandomPoint(_transform.position, 4f, out point))
        {
            hasPoint = true;
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            _navMeshAgent.destination = point;
        }

        if (Vector3.Distance(_transform.position, point) < 0.2f)
        {
            hasPoint = false;
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.RUNNING;
        return state;

    }

    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}


