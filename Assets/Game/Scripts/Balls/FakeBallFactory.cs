using UnityEngine;

public class FakeBallFactory : IBallFactory
{
    private readonly FakeBall _prefab;
    private readonly IBallFactory _ballFactory;
    private readonly IBallDestanationHandler _destanationHandler;

    public FakeBallFactory(IBallDestanationHandler destanationHandler,FakeBall prefab, IBallFactory factory)
    {
        _destanationHandler = destanationHandler;
        _prefab = prefab;
        _ballFactory = factory;
    }

    public Ball Create(Vector2 position, float speed)
    {
        FakeBall ball = GameObject.Instantiate(_prefab, position, Quaternion.identity);
        ball.Init(_destanationHandler,position, speed);
        ball.Init(_ballFactory);
        return ball;
    }
}