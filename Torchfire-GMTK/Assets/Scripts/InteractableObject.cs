using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Interactable", menuName = "Interactable")]
public class InteractableObject : ScriptableObject
{
    public enum type { Lure, Scare };
    public string interactable;
    public float colliderDiameter;
    public type Scalure;
    public float stressChange;
    public bool active;
    public bool hasObject;
    public GameObject foundObject;
    TriggerHandler handler;
    // Start is called before the first frame update
    public void CreateCollider()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Destroy(sphere.GetComponent<MeshRenderer>());
        sphere.transform.localScale = new Vector3(colliderDiameter, colliderDiameter, colliderDiameter);
        sphere.AddComponent<SphereCollider>();
        sphere.GetComponent<SphereCollider>().isTrigger = true;
        sphere.AddComponent<TriggerHandler>().creator = this;
        handler = sphere.GetComponent<TriggerHandler>();

    }

    public void TriggerActivated()
    {
        //Grab info/do functions from scripts on foundObject
        //Each found object should have a "Check requirement" or simialrly named function (needs to be consistent accross), that will handle more advanced logic
    }


}
