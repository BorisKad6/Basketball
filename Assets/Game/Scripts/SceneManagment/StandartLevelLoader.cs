internal class StandartLevelLoader : ILevelLoader
{
    private readonly ISceneLoader _sceneLoader;
    public StandartLevelLoader(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void LoadLevel(int level)
    {
        _sceneLoader.LoadScene("Level");
    }

    public void LoadMenu()
    {
        _sceneLoader.LoadScene("Menu");

    }
}