using UnityEngine;

public class Spawner : MonoBehaviour, IGameStopHandler, IGameResumeHandler
{
    [SerializeField] private Vector2 _borders;
    [SerializeField] private float _spawnRate = 1;

    private float _speed;
    private GameManager _gameManager;
    private IBallFactory[] _ballFactories;
    private Timer _delayTimer;
    public void Start()
    {
        Spawn();
    }
    public void Init(float spawnRate, float ballSpeed, Vector2 borders, params IBallFactory[] factories)
    {
        _borders = borders;
        _spawnRate = spawnRate;
        _ballFactories = factories;
        _speed = ballSpeed;
    }
    public void Spawn()
    {
        float y = Random.Range(_borders.x, _borders.y);

        Vector2 pos = transform.position;
        pos.y += y;
        Ball ball = _ballFactories[Random.Range(0, _ballFactories.Length)].Create(pos, _speed);
        Timer timer = Timer.Start(_spawnRate).OnComplete(Spawn);
        _delayTimer = timer;
    }
    public void OnDrawGizmos()
    {
        Vector2 minPos = transform.position;
        minPos.y += _borders.x;
        Vector2 maxPos = transform.position;
        maxPos.y += _borders.y;
        Gizmos.DrawLine(minPos, maxPos);
    }

    public void OnGameStop()
    {
        _delayTimer.Pause();
    }

    public void OnGameResume()
    {
        _delayTimer.Resume();
    }
}
