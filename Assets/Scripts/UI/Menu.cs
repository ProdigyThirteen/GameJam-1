using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomAttributes;


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
        public ButtonType buttonType;
        public Button button;
        public ButtonHover buttonHover;
        public AudioClip buttonClickSound;
        public AudioClip buttonHoverSound;
    }

    [Category("Menu",TextAnchor.MiddleCenter)]

    [SerializeField] public MenuType menu;

    [SerializeField] public List<MenuButton> buttons = new List<MenuButton>();


    private void Start()
    {
        if (menu != MenuType.MainMenu)
        {
            Hide();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        
    }

    public void Show()
    {
        gameObject.SetActive(true);

        
    }


}
