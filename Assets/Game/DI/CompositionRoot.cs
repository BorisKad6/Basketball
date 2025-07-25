using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompositionRoot
{
    private static CompositionRoot _instance;
    private ProjectInstaller[] _contexts;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadGame()
    {
        ProjectInstaller[] contexts = Resources.LoadAll<ProjectInstaller>("");
        for (int i = 0; i < contexts.Length; i++)
        {
            ProjectInstaller context = ScriptableObject.Instantiate(contexts[i]);
            contexts[i] = context;
        }
        _instance = new CompositionRoot(contexts);
    }
    public CompositionRoot(ProjectInstaller[] contexts)
    {
        this._contexts = new ProjectInstaller[contexts.Length];
        for (int i = 0; i < contexts.Length; i++)
        {
            contexts[i].InstallBindings();
            _contexts[i] = contexts[i];
        }
        SceneManager.sceneLoaded += LoadScene;
    }
    public bool GetGameContext<T>(out T context) where T : ProjectInstaller
    {
        for (int i = 0; i < _contexts.Length; i++)
        {
            if (_contexts[i] is T)
            {
                context = (T)_contexts[i];
                return true;
            }
            
        }
        context = null;
        return false;
    }
    public void LoadScene( Scene scene, LoadSceneMode mode)
    {
        SceneInstaller context = GameObject.FindAnyObjectByType<SceneInstaller>();
        context.Init(this);
        context.InstallBindings();
    }
}