using UnityEngine.SceneManagement;

public interface ILevelLoader 
{
    public void LoadMenu();
    public void LoadLevel(int level);
}
public interface ISurvivalLoader
{
    public void LoadMenu();
    public void LoadSurvival();

}
public interface ISceneLoader
{
    public void LoadScene(string name);
}
