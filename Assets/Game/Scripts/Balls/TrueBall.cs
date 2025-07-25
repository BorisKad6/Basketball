using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrueBall : Ball, IPointerClickHandler
{
    private Action _onTap;
    public void Init(Action onTap)
    {
        _onTap = onTap;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _onTap?.Invoke();
    }
}
