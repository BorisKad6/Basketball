using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputField;
    private Timer _timer;

    public void Init(Timer timer)
    {
        _timer = timer;
    }
    public void Update()
    {
        int time = Mathf.FloorToInt(_timer.ElapsedTime);
        int minuts = Mathf.FloorToInt(time / 60);
        int seconds = time - minuts * 60;
        string output = "";
        if(minuts < 10)
        {
            output += "0";
        }
        output += minuts + ":";
        if (seconds < 10)
        {
            output += "0";
        }
        output += seconds;
        _outputField.text = output;
    }

}