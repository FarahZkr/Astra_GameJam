using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Button _BackToGame;
    public bool PauseCheck = false;
    public GameObject PauseMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;   
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _BackToGame.onClick.AddListener(Continue);
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseCheck)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseCheck)
        {
            Continue();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseCheck = true;
        PauseMenu.SetActive(true);
    }

    private void Continue()
    {
        Time.timeScale = 1;
        PauseCheck = false;
        PauseMenu.SetActive(false);
    }
}
