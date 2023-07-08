using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableDetection : MonoBehaviour
{
    public InteractableObject creator;
    public EventManager eventManager;
    //Temporary system for interaction highlighting when in range, changes material color
    void OnTriggerEnter(Collider coll)
    {
        eventManager.interacted.Invoke();
        Debug.Log("got here");
        creator.foundObject.GetComponent<MeshRenderer>().material = creator.highlight;

    }
    void OnTriggerExit(Collider coll)
    {
        creator.foundObject.GetComponent<MeshRenderer>().material = creator.defaultMat;


    }
}
