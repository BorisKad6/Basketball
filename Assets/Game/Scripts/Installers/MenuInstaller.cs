using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuInstaller : SceneInstaller<GameInstaller>
{
    [SerializeField] private Slider _volume1;
    [SerializeField] private Slider _volume2;
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _survivalBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private SceneManagerLoader _levelManager;
    [SerializeField] private MenuLevelItem _levelItem;
    [SerializeField] private SurvivalModeData _survivalModeData;
    public override void InstallBindings()
    {
        IStorage storage = GameContext.Storage;

        ILevelLoader levelLoader = new BufferedLevelLoader(
            new StandartLevelLoader(GameContext.SceneLoader),
            GameContext.Storage);
        ISurvivalLoader survivalLoader = new SurvivalLoader(GameContext.SceneLoader);
        

        ListEnumerator listEnumerator = FindAnyObjectByType<ListEnumerator>();
        for (int i = 0; i < _survivalModeData.Datas.Length; i++)
        {
            listEnumerator.States.Add(_survivalModeData.Datas[i].Name);
        }
        listEnumerator.Init(storage.GetInt("SurvivalMode"));

        StatsPanel statsPanel = FindAnyObjectByType<StatsPanel>();
        SettingsPanel settingsPanel = FindAnyObjectByType<SettingsPanel>();
        _volume1.value = storage.GetFloat("volume1");
        _volume2.value = storage.GetFloat("volume2");
        settingsPanel.Init(
            storage,
            _volume1,
            _volume2,
            listEnumerator);
        statsPanel.Init(
            storage.GetInt("BestScore"),
            storage.GetInt("LastScore"));
        statsPanel.Close();
        settingsPanel.Close();

        LevelsPanel levelsPanel = FindAnyObjectByType<LevelsPanel>();
        levelsPanel.Init(
            new ItemsFactory(
                _levelItem,
                levelLoader,
                storage),
            10);

        _playBtn.onClick.AddListener(()=>levelLoader.LoadLevel(storage.GetInt("LastLevel")));
        _exitBtn.onClick.AddListener(() => Application.Quit());
        _survivalBtn.onClick.AddListener(survivalLoader.LoadSurvival);
    }
    public void OnDestroy()
    {
        _playBtn.onClick.RemoveAllListeners();
        _exitBtn.onClick.RemoveAllListeners();
        _survivalBtn.onClick.RemoveAllListeners();
    }
}
[Serializable]
public class LevelData
{
    public float BallSpeed;
    public int LifeTime;
    public float SpawnRate;
}
