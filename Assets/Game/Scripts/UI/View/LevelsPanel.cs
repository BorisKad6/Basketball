using System.Collections.Generic;
using UnityEngine;

public class LevelsPanel : Form
{
    [SerializeField] private Transform _content;
    private List<MenuLevelItem> _levelItems = new List<MenuLevelItem>();
    public void Init(ItemsFactory factory, int count)
    {
        for (int i = 0; i < count; i++)
        {
            MenuLevelItem item = factory.Create(i);
            item.transform.parent = _content;
            _levelItems.Add(item);
        }
        Close();
    }
}
public class ItemsFactory
{
    private ILevelLoader _levelManager;
    private IStorage _storage;
    private MenuLevelItem _levelItem;
    public ItemsFactory(MenuLevelItem prefab, ILevelLoader levelManager, IStorage storage)
    {
        _levelItem = prefab;
        _storage = storage;
        _levelManager = levelManager;
    }
    public MenuLevelItem Create(int level)
    {
        MenuLevelItem levelItem = GameObject.Instantiate(_levelItem);
        levelItem.Init(_storage.GetBool("LevelPassed" + (level)),level, _levelManager);
        return levelItem;
    }
}