using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _StartGame;
    [SerializeField] Button _QuitGame;

    //buttons with different option in the main menu
    private void Start()
    {
        _StartGame.onClick.AddListener(StartGame);
        _QuitGame.onClick.AddListener(Quitting);
    }

    private void StartGame()
    {
        ScenesManager.Instance.LoadNewGame();
    }

    private void Quitting()
    {
        Application.Quit();
    }
}