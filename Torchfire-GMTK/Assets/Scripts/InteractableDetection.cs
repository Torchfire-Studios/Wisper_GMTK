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
       /* if (coll.CompareTag("Agent"))
        {
            //eventManager.interacted.Invoke();
            Debug.Log(coll.transform.name);
            Transform go = gameObject.transform.GetChild(2);
            go.gameObject.SetActive(true);
            // creator.foundObject.GetComponent<MeshRenderer>().material = creator.highlight;
        }

        */
    }
}
