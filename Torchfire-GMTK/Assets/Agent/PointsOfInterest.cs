using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgentFSM
{
    public class PointsOfInterest : MonoBehaviour
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

        public bool ClosestPoi()
        {
            Debug.Log(TouchingObjects.Count);
            if(TouchingObjects.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

