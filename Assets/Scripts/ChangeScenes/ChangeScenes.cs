using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] private string gameLevelName;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelOptions;

    public void Play()
    {
        SceneManager.LoadScene(gameLevelName);
    }

    public void Options()
    {
        panelMenu.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void ExitOptions()
    {
        panelMenu.SetActive(true);
        panelOptions.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();  
    }
}
