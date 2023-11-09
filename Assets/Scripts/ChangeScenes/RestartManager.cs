using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    [SerializeField]
    private string gameLevel;
    [SerializeField]
    private string mainMenu;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(gameLevel);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
