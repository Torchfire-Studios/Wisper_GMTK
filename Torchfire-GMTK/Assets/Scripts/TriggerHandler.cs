using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public InteractableObject creator;
    // This would trigger the scare/lure effect
    void OnTriggerEnter(Collider coll)
    {
        creator.TriggerActivated();
    }
}
