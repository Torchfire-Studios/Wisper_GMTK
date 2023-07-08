using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InsanityMeter : MonoBehaviour
{
    [SerializeField]
    Slider instanityMeter;
    [SerializeField] EventManager eventManager;
    float control = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("gradualInsanity", 1f, 1f);
        instanityMeter.value = .5f;
    }


    // Update is called once per frame
    void Update()
    {

    }



    void gradualInsanity()
    {

        instanityMeter.value -= (1f / 60f); //Naturally decreases the insanity as a steady rate

    }

    public void AddInsanity(float add)
    {

        if (instanityMeter.value + add >= 1)
        {
            //Add death logic here
            eventManager.templateEvent.Invoke();
            Debug.Log("got here");
            instanityMeter.value = 1;
            return;
        }
        instanityMeter.value += add;
    }
}
