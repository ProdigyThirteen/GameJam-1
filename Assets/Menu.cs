using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class Menu : MonoBehaviour
{
    [Serializable]
    public enum MenuType
    {
        MainMenu,
        OptionsMenu,
        PauseMenu,
        GameOver,
        None
    }

    [Serializable]
    public enum ButtonType
    {
        Start,
        Options,
        Resume,
        ExitGame,
        ExitDesktop,
        Back
    }

    [Serializable]
    public struct MenuButton
    {
        public ButtonType name;
        public Button button;
    }

    [SerializeField] public MenuType menu;

    [SerializeField] public List<MenuButton> buttons = new List<MenuButton>();

    public void Hide()
    {
        gameObject.SetActive(false);
        
    }

    public void Show()
    {
        gameObject.SetActive(true);
       
    }


}
