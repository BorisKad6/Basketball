using UnityEngine;

public class MenuManager 
{
    private IStorage _storage;
    private ILevelLoader _levelManager;
    public MenuManager(IStorage storage, ILevelLoader manager)
    {
        _storage = storage;
        _levelManager = manager;
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void Play()
    {
        _levelManager.LoadLevel(_storage.GetInt("LastLevel"));
    }
}
