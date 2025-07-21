using UnityEngine;
using UnityEngine.UI;
using DG;
using DG.Tweening;

public class MenuButtonsAnim : MonoBehaviour
{
    [SerializeField] private RectTransform[] _buttons;
    public void Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            Animate(_buttons[i], 0.5f+ i*0.2f);
        }
    }
    public void Animate(RectTransform button, float delay)
    {
        float startX = Camera.main.pixelWidth + button.rect.width;
        float endX = button.transform.position.x;
        Vector2 startPos = new Vector2(startX, button.position.y);
        button.position = startPos;
        button.transform.DOMoveX(endX, delay);
        
    }
}
