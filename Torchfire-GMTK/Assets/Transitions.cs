using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Transitions : MonoBehaviour
{
    public bool Entrance = false;
    public bool Exit = false;

    [SerializeField]
    private Image TransitionPanel;

    private Color PanelColor;
    int i = 0;


    private void Awake()
    {
        PanelColor = TransitionPanel.color;
        Entrance = true;
    }

    private void FixedUpdate()
    {
        if (Entrance && PanelColor.a >= 0 && i >= 30)
        {
            PanelColor.a -= .01f;
            TransitionPanel.color = PanelColor;
        } 
        else if (Exit && PanelColor.a <= 1 && i >= 30)
        {
            PanelColor.a += .01f;
            TransitionPanel.color = PanelColor;
        }
        else if (Entrance && PanelColor.a <= 0 && i >= 30)
        {
            Entrance = false;
        }
        else if (Exit == true && Entrance == false && PanelColor.a >= 1 && i >= 30)
        {
            SceneManager.LoadScene("BasementScene");
        }
        i++;
    }

    private void ExitLevel()
    {
        Exit = true;
    }
}
