using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action ActivateGameOver;
    public static event Action ActivateWinGame;

    private void OnEnable()
    {
        PlayerLife.OnGameOver += GameOver;
        GoalPoint.WinGame += WinGame;

    }
    private void OnDisable()
    {
        PlayerLife.OnGameOver -= GameOver;
    }
  
    private void GameOver()
    {
        ActivateGameOver?.Invoke();
    }

    private void WinGame()
    {
        ActivateWinGame?.Invoke();
    }
}
