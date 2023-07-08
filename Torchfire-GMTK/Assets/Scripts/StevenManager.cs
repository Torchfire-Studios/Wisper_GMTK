using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StevenManager : MonoBehaviour
{
    int order = 1;
    float control = 0;
    public float stevenState = 0;
    [SerializeField] InsanityMeter meter;
    [SerializeField] EventManager eventManager;
    [SerializeField] InteractableObject test;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StevenEvents", 1f, 1f);
        eventManager.templateEvent.AddListener(StevenKills);

    }

    // Update is called once per frame
    void Update()
    {

    }


    void StevenEvents()
    {

        stevenState += .01f * (control * control) / .04f; //Naturally the insanity will top out at 8 minutes, to change minutes change 64 to square of desired minute
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
}
