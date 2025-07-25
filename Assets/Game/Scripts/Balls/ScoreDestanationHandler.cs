public class ScoreDestanationHandler : IBallDestanationHandler
{
    private IScoreCounter _scoreCounter;
    public ScoreDestanationHandler(IScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
    }

    public void OnDestanationReached()
    {
        _scoreCounter.AddScore(1);
    }
}