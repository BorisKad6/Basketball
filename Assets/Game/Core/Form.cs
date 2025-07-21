using UnityEngine;

public class Form : MonoBehaviour
{
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
}