using Assets.CodeBase.Core;
using UnityEngine;

public class SaveLoadService: ISaveLoadService
{
    private PersistentData _persistentData;
    private Extensions _services = Extensions.Instance;
    private FactoryHero _factoryHero;

    public SaveLoadService()
    {
        _factoryHero = _services.GetService<FactoryHero>();
        _persistentData = new PersistentData();
    }

    public void SaveAll()
    {
        _factoryHero.Save(_persistentData);

        PlayerPrefs.SetString("data" ,JsonUtility.ToJson(_persistentData));

        Debug.Log(_persistentData.HeroPosition.y);
        Debug.Log(_persistentData.HeroPosition.x);
        Debug.Log(_persistentData.HeroPosition.z);
        Debug.Log(JsonUtility.ToJson(_persistentData));
        PlayerPrefs.Save();
    }

    public void Load()
    {
        _persistentData = JsonUtility.FromJson<PersistentData>(PlayerPrefs.GetString("data"));
        _factoryHero.Load(_persistentData);
    }
}
