using UnityEngine;
using UnityEngine.EventSystems;

public class FakeBall : Ball, IPointerClickHandler
{
    private IBallFactory _ballFactory;
    public void Init( IBallFactory ballFactory)
    {
        _ballFactory = ballFactory;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _ballFactory.Create(transform.position, Speed);
        Destroy(gameObject);
    }
}
