using UnityEngine;

public interface ILevelLoader 
{
    public void LoadMenu();
    public void LoadSurvival();
    public void LoadLevel(int level);
}
