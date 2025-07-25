using System;
using UnityEngine;

public class TrueBallFactory : IBallFactory
{
    private readonly TrueBall _prefab;
    private readonly Action _onTap;
    private readonly IBallDestanationHandler _destanationHandler;
    public TrueBallFactory(IBallDestanationHandler destanationHandler, Action onTap, TrueBall prefab)
    {
        _onTap = onTap;
        _destanationHandler = destanationHandler;
        _prefab = prefab;
    }

    public Ball Create(Vector2 position, float speed)
    {
        TrueBall ball = GameObject.Instantiate(_prefab, position, Quaternion.identity);
        ball.Init(_destanationHandler,position, speed);
        ball.Init(_onTap);
        return ball;
    }

}