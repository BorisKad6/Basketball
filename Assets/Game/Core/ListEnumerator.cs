using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListEnumerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputField;
    [SerializeField] public List<string> _states;

    public int CurrentState { get; private set; }
    public void Init(int startState)
    {
        CurrentState = startState;
        _outputField.text = _states[CurrentState];
    }
    public void ChooseNext()
    {
        CurrentState += 1;
        if(CurrentState >= _states.Count) CurrentState = 0;
        _outputField.text = _states[CurrentState];
    }
    public void ChoosePrevious()
    {

        CurrentState -= 1;
        if(CurrentState <0) CurrentState = _states.Count-1;
        _outputField.text = _states[CurrentState];
    }
    public string GetCurrentState()
    {
        return _states[CurrentState];
    }
}
