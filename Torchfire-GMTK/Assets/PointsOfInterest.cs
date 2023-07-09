
using System.Collections.Generic;
using UnityEngine;

public class PointsOfInteres : MonoBehaviour
{
    public List<GameObject> TouchingObjects;

    void Start()
    {
        TouchingObjects = new List<GameObject>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!TouchingObjects.Contains(collision.gameObject) && collision.gameObject.tag == "PointOfInterest")
            TouchingObjects.Add(collision.gameObject);
    }

    void OnTriggerExit(Collider collision)
    {
        if (TouchingObjects.Contains(collision.gameObject))
            TouchingObjects.Remove(collision.gameObject);
    }
}