using UnityEngine;

public interface IBallFactory
{
    public Ball Create(Vector2 position, float speed);
}