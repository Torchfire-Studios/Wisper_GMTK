using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Agent")
        {
            Transform go = gameObject.transform.GetChild(2);
            go.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("collided but not with agent");
        }
        
    }
}
