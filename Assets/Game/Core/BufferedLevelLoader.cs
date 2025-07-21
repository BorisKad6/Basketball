using UnityEngine;

public class BufferedLevelLoader : ILevelLoader
{
    ILevelLoader _loader;
    IStorage _storage;
    public BufferedLevelLoader(ILevelLoader loader, IStorage storage)
    {
        _loader = loader;
        _storage = storage;
    }

    public void LoadLevel(int level)
    {
        _storage.SaveInt("LastLevel", level);
        _loader.LoadLevel(level);
    }

    public void LoadMenu()
    {
        _loader.LoadMenu();
    }

    public void LoadSurvival()
    {
        _loader.LoadSurvival();
    }
}
