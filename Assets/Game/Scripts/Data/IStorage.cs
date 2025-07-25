public interface IStorage
{
    public int GetInt(string key);
    public string GetString(string key);
    public float GetFloat(string key);
    public bool GetBool(string key);
    public void SaveInt(string key, int value);
    public void SaveString(string key, string value);
    public void SaveFloat(string key, float value);
    public void SaveBool(string key, bool value);
}