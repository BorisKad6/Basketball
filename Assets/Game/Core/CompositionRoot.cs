using UnityEngine;
using UnityEngine.UI;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private Vector2 _borders;
    [SerializeField] private Vector2 _standartAspect;
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private FakeBall _fakeBall;
    [SerializeField] private TrueBall _trueBall;
    [SerializeField] private float _gameTime = 5;
    private GameManager _gameManager;
    public void Awake()
    {
        InstallBindings();
    }
    public void InstallBindings()
    {
        InteractiveRatioCalculator ratioCalculator = new InteractiveRatioCalculator();
        float ratio = ratioCalculator.Calculate(_standartAspect);
        Camera cam = Camera.main;
        cam.orthographicSize = cam.orthographicSize/ratio;
        Time.timeScale = 1;
        WinPanel winPanel = FindAnyObjectByType<WinPanel>();
        LosePanel losePanel = FindAnyObjectByType<LosePanel>();
        PausePanel pausePanel = FindAnyObjectByType<PausePanel>();
        IStorage storage = new PlayerPrefsStorage();
        ILevelLoader levelLoader = new BufferedLevelLoader(_levelManager, storage);
        //_gameManager = new GameManager(storage,levelLoader, losePanel, winPanel, pausePanel);
        LevelData currentData = _gameConfig.LevelsDates[storage.GetInt("LastLevel")];
        //ScoreCounter scoreCounter = FindAnyObjectByType<ScoreCounter>();
        //scoreCounter.Init(storage);
        IBallDestanationHandler actionDestanationHandler = new ActionDestanationHandler(losePanel.LoseGame);
        IBallDestanationHandler destanationHandler = new ActionDestanationHandler(()=> { });
        TrueBallFactory trueBallFactory = new TrueBallFactory(destanationHandler, losePanel.LoseGame, _trueBall);
        FakeBallFactory fakeBallFactory = new FakeBallFactory(actionDestanationHandler, _fakeBall, trueBallFactory);
        Spawner spawner = FindAnyObjectByType<Spawner>();
        spawner.Init(currentData.SpawnRate, currentData.BallSpeed, new Vector2(_borders.x/ratio, _borders.y/ratio),fakeBallFactory, trueBallFactory);
        winPanel.Init(levelLoader,storage, storage.GetInt("LastLevel"));
        losePanel.Init(levelLoader, storage.GetInt("LastLevel"));
        pausePanel.Init(levelLoader, storage.GetInt("LastLevel"));
        winPanel.Close();
        losePanel.Close();
        pausePanel.Close();
        _pauseBtn.onClick.AddListener(pausePanel.PauseGame);
        TimerView timerView = FindAnyObjectByType<TimerView>();
        timerView.Init(Timer.Start(currentData.LifeTime).OnComplete(winPanel.WinGame));
        
    }
}
