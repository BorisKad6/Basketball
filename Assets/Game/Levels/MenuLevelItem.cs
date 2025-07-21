using TMPro;
using UnityEngine;

public class MenuLevelItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelOutput;
    [SerializeField] private GameObject _toggle;

    private ILevelLoader _levelManager;

    public int Level;

    public void Init(bool passed, int level, ILevelLoader levelManager)
    {
        Level = level;
        _levelOutput.text = (Level + 1).ToString();
        _toggle.SetActive(passed);
        _levelManager = levelManager;
    }

    public void OnChoosed()
    {
        _levelManager.LoadLevel(Level);
    }
}
