using TMPro;
using UnityEngine;

public class StatsPanel : Form
{
    [SerializeField] private TextMeshProUGUI _maxScoreField;
    [SerializeField] private TextMeshProUGUI _lastScoreField;

    public void Init(int maxScore, int lastScore)
    {
        _maxScoreField.text = maxScore.ToString();
        _lastScoreField.text = lastScore.ToString();
    }
}
