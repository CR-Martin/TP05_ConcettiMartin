using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject winMenu;

    private void OnEnable()
    {
        GameManager.ActivateGameOver += GameOver;
        GameManager.ActivateWinGame += WinGame;
    }

    private void OnDisable()
    {
        GameManager.ActivateGameOver -= GameOver;
        GameManager.ActivateWinGame -= WinGame;

    }
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Main music");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        if (Time.timeScale == 1)
        {
            pauseMenu.SetActive(true);
            SetTimeToZero();
        }
        else 
        {
            ResumeGameplay();
        }
    }

    private void GameOver()
    {
        SetTimeToZero();
        gameOverMenu.SetActive(true);

    }
    private void WinGame()
    {
        SetTimeToZero();
        winMenu.SetActive(true);
    }

    public void ChangeScene(string name)
    {
        SetTimeToOne();
        SceneManager.LoadScene(sceneName: name);
    }

    public void ResumeGameplay()
    {
        pauseMenu.SetActive(false);
        SetTimeToOne();
    }
    private void SetTimeToZero()
    {
        Time.timeScale = 0f;
    }

    private void SetTimeToOne()
    {
        Time.timeScale = 1f;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Click()
    {
        AudioManager.Instance.PlayEffect("Click");

    }
}
