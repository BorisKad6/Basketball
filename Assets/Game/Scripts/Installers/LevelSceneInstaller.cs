using Assets.Game.Core;
using UnityEngine;
using UnityEngine.UI;

public class LevelSceneInstaller : GameplaySceneInstaller
{
    [SerializeField] private Vector2 _borders;
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private SceneManagerLoader _levelManager;
    [SerializeField] private FakeBall _fakeBall;
    [SerializeField] private TrueBall _trueBall;
    [SerializeField] private ShadedAppearEffect _effect;
    [SerializeField] private float _gameTime = 5;

    private TimerGameLoopHandler _timerHandler;
    public override void InstallBindings()
    {
        base.InstallBindings();
        int lastLevel = GameContext.Storage.GetInt("LastLevel");
        LevelData currentData = _gameConfig.LevelsDates[lastLevel];
        ILevelLoader levelLoader = new BufferedLevelLoader(
            new StandartLevelLoader(GameContext.SceneLoader), GameContext.Storage);
        IPausePanelPresenter pausePanelPresenter = new LevelsPausePanelPresenter(
            levelLoader,
            GameLoop,
            lastLevel
            );
        ILosePanelPresenter losePanelPresenter = new LevelLosePanelPresenter(
            levelLoader,
            lastLevel);
        IWinPanelPresenter winPanelPresenter = new LevelWinPanelPresenter(
            levelLoader,
            lastLevel,
            _gameConfig.LevelsDates.Length);
        WinPanel winPanel = FindAnyObjectByType<WinPanel>();
        LosePanel losePanel = FindAnyObjectByType<LosePanel>();
        PausePanel pausePanel = FindAnyObjectByType<PausePanel>();
        winPanel.Init(levelLoader,
            GameContext.Storage,
            GameContext.Storage.GetInt("LastLevel"));
        losePanel.Init(losePanelPresenter);
        pausePanel.Init(pausePanelPresenter);
        winPanel.Close();
        losePanel.Close();
        pausePanel.Close();
        _pauseBtn.onClick.AddListener(pausePanel.PauseGame);

        GameLoseHandler loseHandler = new GameLoseHandler(losePanel, GameLoop);
        GameWinHandler winHandler = new GameWinHandler(winPanel, GameLoop);
        IBallDestanationHandler FalseDestanationHandler = new ActionDestanationHandler(loseHandler.OnGameLose);
        IBallDestanationHandler TrueDestanationHandler = new ActionDestanationHandler(()=> { });
        IBallFactory trueBallFactory = new GameLoseHandlerFactory(
            new TrueBallFactory(TrueDestanationHandler,
                loseHandler.OnGameLose,
                _trueBall),
            GameLoop);
        IBallFactory fakeBallFactory = new GameLoseHandlerFactory(
            new FakeBallFactory(FalseDestanationHandler,
                _fakeBall,
                trueBallFactory),
            GameLoop);

        Spawner spawner = FindAnyObjectByType<Spawner>();
        spawner.Init(currentData.SpawnRate,
            currentData.BallSpeed,
            new Vector2(_borders.x/_ratio, _borders.y/_ratio),
            fakeBallFactory,
            trueBallFactory);

        Timer gameTimer = Timer.Start(currentData.LifeTime)
            .OnComplete(winHandler.OnGameWin);
        _timerHandler = new TimerGameLoopHandler(gameTimer);
        TimerView timerView = FindAnyObjectByType<TimerView>();
        timerView.Init(gameTimer);
        GameLoop.AddListener(_timerHandler as IGameResumeHandler);
        GameLoop.AddListener(_timerHandler as IGameStopHandler);

    }
}
