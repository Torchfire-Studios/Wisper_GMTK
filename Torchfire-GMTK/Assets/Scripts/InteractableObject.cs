using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
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
    public Material highlight;
    public Material defaultMat;
    [SerializeField] EventManager eventManager;

    void Start()
    {
        Init();
    }

    // Creates detection collider for npc, will need to be activated
    public void CreateCollider()
    {


        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Destroy(sphere.GetComponent<MeshRenderer>());
        sphere.transform.localScale = new Vector3(colliderDiameter, colliderDiameter, colliderDiameter);
        sphere.AddComponent<SphereCollider>();
        sphere.GetComponent<SphereCollider>().isTrigger = true;
        sphere.AddComponent<TriggerHandler>().creator = this;
        sphere.transform.position = gameObject.transform.position;
        handler = sphere.GetComponent<TriggerHandler>();


    }

    public void TriggerActivated()
    {
        //Grab info/do functions from scripts on foundObject
        //Each found object should have a "Check requirement" or simialrly named function (needs to be consistent accross), that will handle more advanced logic
    }
    //Creates interaction collider that will make object glow when close enough
    public void Init()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Destroy(cube.GetComponent<MeshRenderer>());
        cube.transform.localScale = new Vector3(2, 2, 2);
        cube.GetComponent<BoxCollider>().isTrigger = true;
        cube.AddComponent<InteractableDetection>().creator = this;
        cube.GetComponent<InteractableDetection>().eventManager = eventManager;
        cube.transform.position = transform.position;


    }
}
