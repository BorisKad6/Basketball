using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuCompositionRoot : MonoBehaviour
{
    [SerializeField] private Slider _volume1;
    [SerializeField] private Slider _volume2;
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private MenuLevelItem _levelItem;
    [SerializeField] private SurvivalModeData _survivalModeData;

    private MenuManager _manager;
    public void Awake()
    {
        InstallBindings();
    }
    public void InstallBindings()
    {
        SettingsPanel settingsPanel = FindAnyObjectByType<SettingsPanel>();
        StatsPanel statsPanel = FindAnyObjectByType<StatsPanel>();
        ListEnumerator listEnumerator = FindAnyObjectByType<ListEnumerator>();
        IStorage storage = new PlayerPrefsStorage();
        ILevelLoader levelLoader = new BufferedLevelLoader(_levelManager, storage);
        _volume1.value = storage.GetFloat("volume1");
        _volume2.value = storage.GetFloat("volume2");
        statsPanel.Init(storage.GetInt("BestScore"), storage.GetInt("LastScore"));
        listEnumerator.Init(storage.GetInt("SurvivalMode"));
        for (int i = 0; i < _survivalModeData.Datas.Length; i++)
        {
            listEnumerator._states.Add(_survivalModeData.Datas[i].Name);
        }
        settingsPanel.Init(storage, _volume1,_volume2, listEnumerator);
        statsPanel.Close();
        settingsPanel.Close();
        _manager = new MenuManager(storage, levelLoader);
        _playBtn.onClick.AddListener(_manager.Play);
        _exitBtn.onClick.AddListener(_manager.CloseGame);
        LevelsPanel levelsPanel = FindAnyObjectByType<LevelsPanel>();
        levelsPanel.Init(new ItemsFactory(_levelItem, levelLoader, storage), 10);
    }
    public void OnDestroy()
    {
        _playBtn.onClick.RemoveAllListeners();
        _exitBtn.onClick.RemoveAllListeners();
    }
}
[Serializable]
public class LevelData
{
    public float BallSpeed;
    public int LifeTime;
    public float SpawnRate;
}
