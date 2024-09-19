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
        public ButtonType name;
        public Button button;
    }

    [Category("Menu",TextAnchor.MiddleCenter)]

    [SerializeField] public MenuType menu;

    [SerializeField] public List<MenuButton> buttons = new List<MenuButton>();

    [Category("Animation", TextAnchor.MiddleCenter)]

    [SerializeField] private bool isEnabled = false;    

    [SerializeField] private AnimationCurve easeInOutCurve;

    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private Vector2 defaultScale;
    [SerializeField] private Vector2 startScale;

    [SerializeField] private TweenManager tweenManager;

    private void Awake()
    {
        
    
        if(isEnabled)
        {
            tweenManager = gameObject.GetComponent<TweenManager>();

            defaultScale = gameObject.GetComponent<RectTransform>().localScale;
        }
            

        
    }

    private void Start()
    {
        if (menu != MenuType.MainMenu)
        {
            Hide();
        }
    }

    private void OnEnable()
    {
        
    }

    private void HandleTweening()
    {
        if (!isEnabled)
            return;

        // Example: Tween position over 2 seconds using the ease-in-out curve
        tweenManager.TweenLocalPosition(gameObject.GetComponent<RectTransform>(), startPos, endPos, 2f, easeInOutCurve);

        // Example: Tween scale over 1.5 seconds using the same curve
        tweenManager.TweenLocalScale(gameObject.GetComponent<RectTransform>(), startScale, defaultScale, 1.5f, easeInOutCurve);

        // Example: Tween float value (like opacity) using the curve
        tweenManager.TweenFloat(SetOpacity, 0f, 1f, 2f, easeInOutCurve);
    }

    private void SetOpacity(float value)
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if(canvasGroup)
        {
            canvasGroup.alpha = value;
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
