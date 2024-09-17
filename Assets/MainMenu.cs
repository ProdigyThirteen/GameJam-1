using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    
    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneHandler.Instance.LoadScene("Vasco_Test_Scene");
    }
}
