using UnityEngine;

public class MonoGameStopHandler : MonoBehaviour, IGameStopHandler, IGameResumeHandler
{
    public MonoBehaviour Mono;

    public void OnGameResume()
    {
        Mono.enabled = (true);
    }

    public void OnGameStop()
    {
        Mono.enabled = (false);
    }
}
