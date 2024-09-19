using CustomAttributes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using DevLocker.Utils;
using System.Collections;



public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;

    [Category("Current Scene",TextAnchor.MiddleCenter)]
    [SerializeField]private SceneReference currentScene;

    [Category("Previous Scene", TextAnchor.MiddleCenter)]
    [SerializeField] private SceneReference previousScene;

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

        Instance.InitializeSceneHandler();

        DontDestroyOnLoad(this);
    }

    private void InitializeSceneHandler()
    {         
        SceneManager.sceneLoaded += OnSceneLoaded;

        SceneManager.sceneUnloaded += OnSceneUnloaded;
        
        currentScene = new SceneReference(SceneManager.GetActiveScene().path);
    }

    private void OnSceneUnloaded(Scene arg0)
    {
        previousScene = new SceneReference(arg0.path);
    }

    private void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
    {
        currentScene = new SceneReference(loadedScene.path);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneDelay(string sceneName, float delay)
    {
        StartCoroutine(CoroutineUtility.DelayAction(delay, () => SceneManager.LoadScene(sceneName)));
  
    }

}
