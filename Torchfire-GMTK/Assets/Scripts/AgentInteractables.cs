using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentInteractables : MonoBehaviour
{
    //public List<>

    public void Interact()
    {
        int LayerComplete = LayerMask.NameToLayer("complete");
        gameObject.layer = LayerComplete;
        Debug.Log("layerchange");
    }
}
