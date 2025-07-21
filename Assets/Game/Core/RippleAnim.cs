using DG.Tweening;
using UnityEngine;

public class RippleAnim : MonoBehaviour
{
    public void OnEnable()
    {
        Decrease();
    }
    public void OnDisable()
    {
    }
    public void Decrease()
    {
        transform.DOScale(0.8f, 3).OnComplete(Increase);
    }
    public void Increase()
    {

        transform.DOScale(1.1f, 3).OnComplete(Decrease);
    }
}
