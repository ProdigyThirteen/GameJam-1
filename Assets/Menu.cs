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
    enum ButtonType
    {
        Start,
        Options,
        Resume,
        ExitGame,
        ExitDesktop,
        Back
    }

    [Serializable]
    struct MenuButton
    {
        public ButtonType name;
        public Button button;
    }

    [SerializeField] public MenuType menu;

    [SerializeField] private List<MenuButton> buttons = new List<MenuButton>();

    public UnityEvent<MenuType> OnHidden;

    public UnityEvent<MenuType> OnShown;

    private void Awake()
    {
        foreach (var button in buttons)
        {
            switch (button.name)
            {
                case ButtonType.Start:
                    button.button.onClick.AddListener(() => SceneHandler.Instance.LoadScene("PauseMenuTest"));
                    break;
                case ButtonType.Options:
                    button.button.onClick.AddListener(() => MenuHandler.Instance.SwapMenu(MenuType.OptionsMenu, menu));
                    break;
                case ButtonType.Resume:
                    button.button.onClick.AddListener(() => MenuHandler.Instance.ResumeGame());
                    break;
                case ButtonType.ExitGame:
                    button.button.onClick.AddListener(() => SceneHandler.Instance.LoadScene("MainMenu"));
                    break;
                case ButtonType.ExitDesktop:
                    button.button.onClick.AddListener(() => Application.Quit());
                    break;
                case ButtonType.Back:
                    button.button.onClick.AddListener(() => MenuHandler.Instance.SwapToPreviousMenu());
                break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        OnHidden?.Invoke(menu);
        
    }

    public void Show()
    {
        gameObject.SetActive(true);
        OnShown?.Invoke(menu);
    }


}
