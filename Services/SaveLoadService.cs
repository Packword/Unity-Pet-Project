using Assets.CodeBase.Core;
using UnityEngine;

public class SaveLoadService: ISaveLoadService
{
    private PersistentData _persistentData;
    private readonly Extensions _services = Extensions.Instance;
    private readonly FactoryHero _factoryHero;

    public SaveLoadService(FactoryHero factoryHero)
    {
        _factoryHero = factoryHero;
        _persistentData = new PersistentData();
    }

    public void SaveAll()
    {
        _factoryHero.Save(_persistentData);

        PlayerPrefs.SetString("data" ,JsonUtility.ToJson(_persistentData));
        PlayerPrefs.Save();
    }

    public void Load()
    {
        _persistentData = JsonUtility.FromJson<PersistentData>(PlayerPrefs.GetString("data"));
        _factoryHero.Load(_persistentData);
    }
}
