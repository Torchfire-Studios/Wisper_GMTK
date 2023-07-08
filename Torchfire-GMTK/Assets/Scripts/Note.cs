using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] string title;
    [SerializeField] string desc;
    [SerializeField] float stress;
    [SerializeField] InsanityMeter meter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddStress()
    {
        meter.AddInsanity(stress);
    }
}
