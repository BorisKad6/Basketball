using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SurvivalModeData", menuName = "SurvivalModeData")]
public class SurvivalModeData : ScriptableObject
{
    public SurvivalModeData.Data[] Datas;

    [Serializable]
    public class Data
    {
        public string Name;
        public float SpawnRate;
        public float BallSpeed;
    }
}