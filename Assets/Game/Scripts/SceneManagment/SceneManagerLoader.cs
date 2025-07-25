using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerLoader : ISceneLoader
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
