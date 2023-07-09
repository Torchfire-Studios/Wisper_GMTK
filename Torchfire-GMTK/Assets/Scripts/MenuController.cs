using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject Credits;

    public void StartGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void OpenMenu()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
    }

}
