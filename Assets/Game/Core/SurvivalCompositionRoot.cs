using UnityEngine;
using UnityEngine.UI;
public class SurvivalCompositionRoot : MonoBehaviour
{
    [SerializeField] private Vector2 _borders;
    [SerializeField] private Vector2 _standartAspect;
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private FakeBall _fakeBall;
    [SerializeField] private TrueBall _trueBall;
    [SerializeField] private SurvivalModeData _modeData;
    private GameManager _gameManager;
    private MenuManager _manager;
    private void Awake()
    {
        InstallBindings();
    }
    public void InstallBindings()
    {
        IStorage storage = new PlayerPrefsStorage();
        int currentMode =storage.GetInt("SurvivalMode");
        SurvivalModeData.Data modeData = _modeData.Datas[currentMode];
        InteractiveRatioCalculator ratioCalculator = new InteractiveRatioCalculator();
        float ratio = ratioCalculator.Calculate(_standartAspect);
        Camera cam = Camera.main;
        cam.orthographicSize = cam.orthographicSize / ratio;
        Time.timeScale = 1;
        LosePanel losePanel = FindAnyObjectByType<LosePanel>();
        PausePanel pausePanel = FindAnyObjectByType<PausePanel>();
        ILevelLoader levelLoader = new SurvivalLoader(_levelManager);
       // _gameManager = new GameManager(storage, levelLoader, losePanel, null, pausePanel);
        ScoreCounter scoreCounter = FindAnyObjectByType<ScoreCounter>();
        scoreCounter.Init(storage);
        IBallDestanationHandler actionDestanationHandler = new ActionDestanationHandler(losePanel.LoseGame);
        IBallDestanationHandler destanationHandler = new ScoreDestanationHandler(scoreCounter);
        TrueBallFactory trueBallFactory = new TrueBallFactory(destanationHandler, losePanel.LoseGame, _trueBall);
        FakeBallFactory fakeBallFactory = new FakeBallFactory(actionDestanationHandler, _fakeBall, trueBallFactory);
        Spawner spawner = FindAnyObjectByType<Spawner>();
        spawner.Init(modeData.SpawnRate, modeData.BallSpeed, new Vector2(_borders.x / ratio, _borders.y / ratio), fakeBallFactory, trueBallFactory);
        losePanel.Init(levelLoader, storage.GetInt("LastLevel"));
        pausePanel.Init(levelLoader, storage.GetInt("LastLevel"));
        losePanel.Close();
        pausePanel.Close();
        _pauseBtn.onClick.AddListener(pausePanel.PauseGame);

    }
}
public class SurvivalLoader : ILevelLoader
{
    private ILevelLoader _levelLoader;

    public SurvivalLoader(ILevelLoader loader)
    {
        _levelLoader = loader;

    }
    public void LoadLevel(int level)
    {
        _levelLoader.LoadSurvival();
    }

    public void LoadMenu()
    {
        _levelLoader.LoadMenu();
    }

    public void LoadSurvival()
    {
        _levelLoader.LoadSurvival();
    }
}
