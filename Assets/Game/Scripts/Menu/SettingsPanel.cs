using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : Form
{
    private IStorage _storage;
    private Slider _volume1;
    private Slider _volume2;
    private ListEnumerator _listEnumerator;
    public void Init(IStorage storage, Slider volume1, Slider volume2, ListEnumerator listEnumerator)
    {
        _storage = storage;
        _volume1 = volume1;
        _volume2 = volume2;
        _listEnumerator = listEnumerator;
    }
    private void OnDestroy()
    {
        _storage.SaveFloat("volume1", _volume1.value);
        _storage.SaveFloat("volume2", _volume2.value);
        _storage.SaveInt("SurvivalMode", _listEnumerator.CurrentState);
    }
}
