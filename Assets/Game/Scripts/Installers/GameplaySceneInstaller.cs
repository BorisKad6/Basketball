using UnityEngine;

public class GameplaySceneInstaller : SceneInstaller<GameInstaller>
{
    [SerializeField] private Vector2 _standartAspect = new Vector2(1920, 1080);
    protected float _ratio;
    protected GameLoop GameLoop { get; private set; }
    public override void InstallBindings()
    {
        InteractiveRatioCalculator ratioCalculator = new InteractiveRatioCalculator();
        _ratio = ratioCalculator.Calculate(_standartAspect);
        Camera cam = Camera.main;
        cam.orthographicSize = cam.orthographicSize / _ratio;

        GameLoop = new GameLoop();

        Spawner spawner = FindAnyObjectByType<Spawner>();
        GameLoop.AddListener(spawner as IGameResumeHandler);
        GameLoop.AddListener(spawner as IGameStopHandler);
    }
}