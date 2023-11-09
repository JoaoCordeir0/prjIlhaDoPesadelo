using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField]
    private string gameLevel;
    [SerializeField]
    private string mainMenu;

    public void ReloadGame()
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
