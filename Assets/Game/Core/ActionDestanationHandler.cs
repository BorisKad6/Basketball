using System;

public class ActionDestanationHandler : IBallDestanationHandler
{
    private Action _action;
    public ActionDestanationHandler(Action action)
    {
        _action = action;
    }
    public void OnDestanationReached()
    {
        _action?.Invoke();
    }
}