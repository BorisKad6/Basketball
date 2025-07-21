using UnityEngine;

public class PlayerPrefsStorage : IStorage
{
    public int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    public float GetFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    public string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    public void SaveFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public bool GetBool(string key)
    {
        return PlayerPrefs.GetInt("b" + key) == 1;
    }

    public void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt("b" + key, value ? 1 : 0);
    }
}