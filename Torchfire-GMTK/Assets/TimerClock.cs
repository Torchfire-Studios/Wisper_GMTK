
using UnityEngine;
using System.Collections;

public class TimerClock : MonoBehaviour
{
    private float timerDuration = 5f;  // Duration of the timer in seconds
    private float timer;              // Current timer value
    [SerializeField] GameObject[] go;

    private bool isTimerRunning;      // Flag to track if the timer is currently running

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            // Update the timer value
            timer -= Time.deltaTime;

            // Check if the timer has reached zero
            if (timer <= 0f)
            {
                TimerComplete(0);
            }
        }
    }

    private void StartTimer()
    {
        timer = timerDuration;
        isTimerRunning = true;
    }

    private void TimerComplete(int counter)
    {
        // Timer has reached zero, do something
        Debug.Log("Timer Complete");

        int randomIndex = Random.Range(0, go.Length);
        Transform light = go[randomIndex].transform.GetChild(2);
        if (light.gameObject.activeSelf)
        {
            light.gameObject.SetActive(false);
            timer = 5f;
        }
        else
        {
            if (counter>=10)
            {
                //UnityEvent
                Application.Quit();
                isTimerRunning = false;
                return;
            }
            TimerComplete(counter);
        }
    }
}