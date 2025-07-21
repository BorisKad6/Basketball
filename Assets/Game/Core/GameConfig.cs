using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    public LevelData[] LevelsDates;
}
