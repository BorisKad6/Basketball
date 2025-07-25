using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour, IScoreCounter
{
    [SerializeField] private TextMeshProUGUI _outputPanel;

    private IStorage _storage;
    public int Score { get; private set; }
    public int MaxScore { get; private set; }

    public void Init(IStorage storage)
    {
        _storage = storage;
        _outputPanel.text = Score.ToString();
        MaxScore = _storage.GetInt("BestScore");
        _storage.SaveInt("LastScore", 0);
    }
    public void AddScore(int score)
    {
        Score += score;
        _outputPanel.text = Score.ToString();
        _storage.SaveInt("LastScore", Score);
        if(Score > MaxScore)
        {

            _storage.SaveInt("BestScore", Score);
        }

    }
}