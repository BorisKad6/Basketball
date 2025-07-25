using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

internal class GameLoseHandlerFactory : IBallFactory
{
    private IBallFactory trueBallFactory;
    private readonly GameLoop _gameLoop;

    public GameLoseHandlerFactory(IBallFactory trueBallFactory, GameLoop gameLoop)
    {
        this.trueBallFactory = trueBallFactory;
        _gameLoop = gameLoop;
    }

    public Ball Create(Vector2 position, float speed)
    {
        Ball ball = trueBallFactory.Create(position, speed);
        MonoGameStopHandler gameStopHandler = ball.AddComponent<MonoGameStopHandler>();
        gameStopHandler.Mono = ball;
        _gameLoop.AddListener(gameStopHandler as IGameResumeHandler);
        _gameLoop.AddListener(gameStopHandler as IGameStopHandler);
        return ball;
    }
}