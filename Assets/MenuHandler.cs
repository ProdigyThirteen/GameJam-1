using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomAttributes;
using static Menu;
using UnityEditor;



public class MenuHandler : MonoBehaviour
{
    public static MenuHandler Instance; 


    [SerializeField] private List<Menu> menus = new List<Menu>();

    [SerializeField] private MenuType currentMenu;

    [SerializeField] private MenuType previousMenu;

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

        currentMenu = MenuType.None;
        previousMenu = MenuType.None;
    }


    public void SwapMenu(Menu.MenuType newMenu, MenuType prevMenu = MenuType.None)
    {
        
        foreach (var menu in menus)
        {
            if (menu.menu == newMenu)
            {
                menu.gameObject.SetActive(true);
                currentMenu = newMenu;

                if(prevMenu != MenuType.None)
                    previousMenu = prevMenu;
            }
            else
            {
                menu.gameObject.SetActive(false);
            }
        }

        Resume();

    }

    public void SwapToPreviousMenu()
    {
        SwapMenu(previousMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentMenu == MenuType.OptionsMenu)
                return;

            foreach (var menu in menus)
            {
                if (menu.menu == Menu.MenuType.PauseMenu && menu.gameObject.activeSelf)
                {
                    menu.gameObject.SetActive(false);
                    Resume();
                }
                else if (menu.menu == Menu.MenuType.PauseMenu && !menu.gameObject.activeSelf)
                {
                    menu.gameObject.SetActive(true);
                    Pause();
                }
            }
        }
    }

    public void ResumeGame()
    {
        foreach (var menu in menus)
        {
            if (menu.menu == Menu.MenuType.PauseMenu && menu.gameObject.activeSelf)
            {
                menu.gameObject.SetActive(false);
                Resume();
            }
            else if (menu.menu == Menu.MenuType.PauseMenu && !menu.gameObject.activeSelf)
            {
                menu.gameObject.SetActive(true);
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void Resume()
    {
        Time.timeScale = 1;
        
    }


    


}
