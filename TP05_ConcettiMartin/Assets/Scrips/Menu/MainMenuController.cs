using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(sceneName: name);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
