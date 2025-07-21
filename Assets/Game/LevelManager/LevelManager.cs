using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelManager", menuName = "LevelManager")]
public class LevelManager : ScriptableObject, ILevelLoader
{
    [SerializeField] private string _menu;
    [SerializeField] private string _survivalMode;
    [SerializeField] private string _level;

    public void LoadSurvival()
    {
        SceneManager.LoadScene(_survivalMode);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(_menu);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(_level);

    }
}
