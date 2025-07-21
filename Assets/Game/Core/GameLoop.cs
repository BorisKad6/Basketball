using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public static void StopGame()
    {
        MonoBehaviour[] Handlers = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        for (int i = 0; i < Handlers.Length; i++)
        {
            if (Handlers[i] is IGameStopHandler)
            {
                ((IGameStopHandler)Handlers[i]).OnGameStop();
            }
        }
    }
    public static void ResumeGame()
    {
        MonoBehaviour[] Handlers = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        for (int i = 0; i < Handlers.Length; i++)
        {
            if (Handlers[i] is IGameResumeHandler)
            {
                ((IGameResumeHandler)Handlers[i]).OnGameResume();
            }
        }
    }
}
