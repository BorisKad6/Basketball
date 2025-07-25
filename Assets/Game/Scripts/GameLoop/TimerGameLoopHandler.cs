internal class TimerGameLoopHandler : IGameStopHandler, IGameResumeHandler
{
    private readonly Timer _timer;
    public TimerGameLoopHandler(Timer timer)
    {
        _timer = timer;
    }

    public void OnGameResume()
    {
        _timer?.Resume();
    }

    public void OnGameStop()
    {
        _timer?.Stop();
    }
}