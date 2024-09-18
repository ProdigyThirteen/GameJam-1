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

    private void Awake()
    {
        //foreach (var button in buttons)
        //{
        //    switch (button.name)
        //    {
        //        case ButtonType.Start:
        //            button.button.onClick.AddListener(() => SceneHandler.Instance.LoadScene("PauseMenuTest"));
        //            button.button.onClick.AddListener(() => MenuHandler.Instance.HideAllMenus());
        //            button.button.onClick.AddListener(() => MenuHandler.Instance.SetCurrentMenu(MenuType.None));
        //            button.button.onClick.AddListener(() => MenuHandler.Instance.SetPreviousMenu(MenuType.MainMenu));
        //            button.button.onClick.AddListener(() => MenuHandler.Instance.Resume());
        //            break;
        //        case ButtonType.Options:
        //            button.button.onClick.AddListener(() => MenuHandler.Instance.SwapMenu(MenuType.OptionsMenu, menu));
        //            break;
        //        case ButtonType.Resume:
        //            button.button.onClick.AddListener(() => MenuHandler.Instance.HandlePauseGame());
        //            break;
        //        case ButtonType.ExitGame:
        //            button.button.onClick.AddListener(() => SceneHandler.Instance.LoadScene("MainMenu"));
        //            button.button.onClick.AddListener(() => MenuHandler.Instance.SwapMenu(MenuType.MainMenu, menu));
        //            break;
        //        case ButtonType.ExitDesktop:
        //            button.button.onClick.AddListener(() => Application.Quit());
        //            break;
        //        case ButtonType.Back:
        //            button.button.onClick.AddListener(() => MenuHandler.Instance.SwapToPreviousMenu());
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}
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
