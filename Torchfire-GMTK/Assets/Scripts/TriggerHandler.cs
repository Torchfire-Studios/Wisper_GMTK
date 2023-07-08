using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public InteractableObject creator;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider coll)
    {
        creator.TriggerActivated();
    }
}
