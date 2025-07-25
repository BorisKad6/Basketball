using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : IGameLoop
{
    private List<WeakReference<IGameResumeHandler>> _resumeHandlers = new();
    private List<WeakReference<IGameStopHandler>> _stopHandlers = new();

    public void AddListener(IGameResumeHandler handler)
    {
        _resumeHandlers.Add(new WeakReference<IGameResumeHandler>(handler));
    }

    public void AddListener(IGameStopHandler handler)
    {
        _stopHandlers.Add(new WeakReference<IGameStopHandler>(handler));
    }

    public void StopGame()
    {
        for (int i = _stopHandlers.Count - 1; i >= 0; i--)
        {
            if (_stopHandlers[i].TryGetTarget(out var handler) && !handler.Equals(null))
            {
                handler.OnGameStop();
            }
            else
            {
                _stopHandlers.RemoveAt(i);
            }
        }
    }

    public void ResumeGame()
    {
        for (int i = _resumeHandlers.Count - 1; i >= 0; i--)
        {
            if (_resumeHandlers[i].TryGetTarget(out var handler) && !handler.Equals(null))
            {
                handler.OnGameResume();
            }
            else
            {
                _resumeHandlers.RemoveAt(i);
            }
        }
    }
}

internal interface IGameLoop
{

    public void StopGame();
    public void ResumeGame();
}