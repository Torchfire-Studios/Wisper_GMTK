using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StevenManager : MonoBehaviour
{
    int order = 1;
    float control = 0;
    public float stevenState = 0;
    int interactionCount = 0;
    [SerializeField] InsanityMeter meter;
    [SerializeField] EventManager eventManager;
    [SerializeField] InteractableObject test;
    // Start is called before the first frame update
    void Start()
    {
        //Add scene check when scenes are set, only initiate steve timer if it's not the tutorial
        InvokeRepeating("StevenEvents", 1f, 1f);
        eventManager.templateEvent.AddListener(StevenKills);
        eventManager.interacted.AddListener(Interacted);
        test.CreateCollider();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void StevenEvents()
    {
        //Formula to increase Steven frequency exponentially, increase the divided by number to descrease the amount of time. 
        //Forula is y=x^2/t^2, t being the variable, put it into desmos to visualize the intensity you want
        //Include y=(1/60)x in desmos to visualize the point of no return for the player

        stevenState += .01f * (control * control) / .04f;

        control += 1f / 60f;

        if (stevenState >= order)
        {
            // Debug.Log("boo steven is here");
            order += 1;
            meter.AddInsanity(.1f);
        }
    }

    void StevenKills()
    {
        Debug.Log("Steven has killed");
    }
    void Interacted()
    {
        //Temporary interaction tracker, this will be used the the tutorial to have Steven show up when the user has done enough interations
        interactionCount++;
        if (interactionCount > 5)
        {
            meter.AddInsanity(.5f);
        }
    }
}
