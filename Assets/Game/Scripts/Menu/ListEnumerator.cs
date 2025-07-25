using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListEnumerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputField;
    [SerializeField] public List<string> States;

    public int CurrentState { get; private set; }
    public void Init(int startState)
    {
        CurrentState = startState;
        _outputField.text = States[CurrentState];
    }
    public void ChooseNext()
    {
        CurrentState += 1;
        if(CurrentState >= States.Count) CurrentState = 0;
        _outputField.text = States[CurrentState];
    }
    public void ChoosePrevious()
    {

        CurrentState -= 1;
        if(CurrentState <0) CurrentState = States.Count-1;
        _outputField.text = States[CurrentState];
    }
    public string GetCurrentState()
    {
        return States[CurrentState];
    }
}
