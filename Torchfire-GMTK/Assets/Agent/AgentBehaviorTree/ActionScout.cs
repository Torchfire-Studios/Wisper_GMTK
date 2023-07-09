using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using System.Collections.ObjectModel;


public class ActionScout : Node
{
    private static int _enemyLayerMask = 7;
    private Transform _transform; //agent's transform
    private NavMeshAgent _navMeshAgent;
    private Vector3 point;

    public ActionScout(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
       // _enemyLayerMask = LayerMask.NameToLayer("interact");
        if (Vector3.Distance(_transform.position, AgentBT.destination) > 0.2f)//has destination
        {
            state = NodeState.RUNNING;
            return state;
        }

        //look for interactables

        //look for points of interest
        Collider[] interactables = Physics.OverlapSphere(
            _transform.position, AgentBT.interactRange, _enemyLayerMask);
        if (interactables.Length > 0)
        {
            foreach (var collider in interactables){
                Debug.Log(collider.gameObject.layer == _enemyLayerMask);
            }

            //Rigidbody rb = interactables[0].gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(Vector3.forward * 10f, ForceMode.Force);
            AgentInteractables interactScript = interactables[0].transform.gameObject.GetComponent<AgentInteractables>();
            //interactScript.Interact();
            
            AgentBT.agentState = AgentState.LURED;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
        /*

        //look for points of interest
        Collider[] colliders = Physics.OverlapSphere(
            _transform.position, AgentBT.fovRange, _enemyLayerMask);

        if (colliders.Length > 0)
        {
            Debug.Log("Scouting");
            //parent.parent.SetData("target", colliders[0].transform);
            AgentBT.destination = colliders[0].transform.position;
            //_animator.SetBool()
        }
        else
        {
            //random location
            if(RandomPoint(_transform.position, 4f, out point))
            {
                AgentBT.destination = point;
            }
            else
            {
                state = NodeState.RUNNING;
                return state;
            }
        }

        state = NodeState.SUCCESS;
        return state;
        */
    }

    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
