using Assets.Game.Core;
using UnityEngine;
using UnityEngine.UI;
public class SurvivalSceneInstaller : GameplaySceneInstaller
{
    [SerializeField] private Vector2 _borders;
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private SceneManagerLoader _levelManager;
    [SerializeField] private FakeBall _fakeBall;
    [SerializeField] private TrueBall _trueBall;
    [SerializeField] private SurvivalModeData _modeData;
    public override void InstallBindings()
    {
        base.InstallBindings();
        IStorage storage = GameContext.Storage;
        int currentMode =storage.GetInt("SurvivalMode");
        SurvivalModeData.Data modeData = _modeData.Datas[currentMode];

        ISceneLoader sceneLoader = GameContext.SceneLoader;
        ISurvivalLoader loader = new SurvivalLoader(sceneLoader);

        ScoreCounter scoreCounter = FindAnyObjectByType<ScoreCounter>();
        scoreCounter.Init(storage);

        IPausePanelPresenter pausePanelPresenter = new SurvivalPausePanelPresenter(loader, GameLoop);
        ILosePanelPresenter losePanelPresenter = new SurvivalLosePanelPresenter(loader);
        LosePanel losePanel = FindAnyObjectByType<LosePanel>();
        PausePanel pausePanel = FindAnyObjectByType<PausePanel>();
        losePanel.Init(losePanelPresenter);
        pausePanel.Init(pausePanelPresenter);
        losePanel.Close();
        pausePanel.Close();

        GameLoseHandler loseHandler = new GameLoseHandler(losePanel, GameLoop);
        IBallDestanationHandler actionDestanationHandler = new ActionDestanationHandler(loseHandler.OnGameLose);
        IBallDestanationHandler destanationHandler = new ScoreDestanationHandler(scoreCounter);
        IBallFactory trueBallFactory = new GameLoseHandlerFactory(
            new TrueBallFactory(destanationHandler,
                loseHandler.OnGameLose,
                _trueBall),
            GameLoop);
        IBallFactory fakeBallFactory = new GameLoseHandlerFactory(
            new FakeBallFactory(actionDestanationHandler,
                _fakeBall,
                trueBallFactory),
            GameLoop);

        Spawner spawner = FindAnyObjectByType<Spawner>();
        spawner.Init(modeData.SpawnRate,
            modeData.BallSpeed,
            new Vector2(_borders.x / _ratio, _borders.y / _ratio),
            fakeBallFactory,
            trueBallFactory);

        _pauseBtn.onClick.AddListener(pausePanel.PauseGame);

    }
}
public class SurvivalLoader : ISurvivalLoader
{
    private ISceneLoader _loader;

    public SurvivalLoader(ISceneLoader loader)
    {
        _loader = loader;

    }

    public void LoadMenu()
    {
        _loader.LoadScene("Menu");
    }

    public void LoadSurvival()
    {
        _loader.LoadScene("Survival");
    }
}
