using System.Collections.Generic;
using UnityEngine;
using CustomAttributes;
using static Menu;
using UnityEngine.UI;
using System;
using DevLocker.Utils;


public class MenuHandler : MonoBehaviour
{
    public static MenuHandler Instance; 

    [SerializeField] private List<Menu> menus = new List<Menu>();

    [SerializeField, ReadOnly] public MenuType currentMenu;

    [SerializeField, ReadOnly] public MenuType previousMenu;

    [SerializeField] private SceneReference sceneToLoadOnStart;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);

        currentMenu = MenuType.None;
        previousMenu = MenuType.None;

        InitButtons();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentMenu == MenuType.OptionsMenu || currentMenu == MenuType.MainMenu)
                return;

            HandlePauseGame();
        }
    }

    private void InitButtons()
    {
        foreach (Menu menu in menus)
        {
            foreach (var button in menu.buttons)
            {
                switch (button.name)
                {
                    case ButtonType.Start:
                        button.button.onClick.AddListener(() => SceneHandler.Instance.LoadScene(sceneToLoadOnStart.SceneName));
                        button.button.onClick.AddListener(() => HideAllMenus());
                        button.button.onClick.AddListener(() => SetCurrentMenu(MenuType.None));
                        button.button.onClick.AddListener(() => SetPreviousMenu(MenuType.MainMenu));
                        button.button.onClick.AddListener(() => Resume());
                        break;
                    case ButtonType.Options:
                        button.button.onClick.AddListener(() => SwapMenu(MenuType.OptionsMenu, menu.menu));
                        break;
                    case ButtonType.Resume:
                        button.button.onClick.AddListener(() => HandlePauseGame());
                        break;
                    case ButtonType.ExitGame:
                        button.button.onClick.AddListener(() => SceneHandler.Instance.LoadScene("MainMenu"));
                        button.button.onClick.AddListener(() => SwapMenu(MenuType.MainMenu, menu.menu));
                        break;
                    case ButtonType.ExitDesktop:
                        button.button.onClick.AddListener(() => Application.Quit());
                        break;
                    case ButtonType.Back:
                        button.button.onClick.AddListener(() => SwapToPreviousMenu());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public void SwapMenu(Menu.MenuType newMenu, MenuType prevMenu = MenuType.None)
    {
        
        foreach (var menu in menus)
        {
            if (menu.menu == newMenu)
            {
               menu.Show();
                currentMenu = newMenu;


               if(prevMenu != MenuType.None)
                    previousMenu = prevMenu;
            }
            else
            {
                menu.Hide();
            }
        }

        

    }

    public void SwapToPreviousMenu()
    {
        SwapMenu(previousMenu, MenuType.OptionsMenu);
    }

    public void HideAllMenus()
    {
        foreach (var menu in menus)
        {
            menu.gameObject.SetActive(false);
        }
    }



    public void HandlePauseGame()
    {
        foreach (var menu in menus)
        {
            if (menu.menu == Menu.MenuType.PauseMenu && menu.gameObject.activeSelf)
            {
                menu.Hide();
                SetPreviousMenu(MenuType.PauseMenu);
                SetCurrentMenu(MenuType.None);
                Resume();
            }
            else if (menu.menu == Menu.MenuType.PauseMenu && !menu.gameObject.activeSelf)
            {
                menu.Show();
                SetCurrentMenu(MenuType.PauseMenu);
                
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        
    }

    public void SetPreviousMenu(MenuType menu)
    {
        previousMenu = menu;
    }

    public void SetCurrentMenu(MenuType menu)
    {
        currentMenu = menu;
    }
    


}
