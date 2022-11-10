using UnityEngine;
using Assets.CodeBase.Core;
using System.Collections.Generic;

public partial class FactoryHero: IService
{
    private readonly GameObject _heroPrefab;
    private readonly Extensions _services = Extensions.Instance;
    private SaveLoadService _saveLoadService;
    private IWatcher _watcher;


    public FactoryHero(GameObject hero)
    { 
        _heroPrefab = hero;
    }

    public void BuildHero(Vector3 at) 
    {
        GameObject player = GameObject.Instantiate(_heroPrefab, at, Quaternion.identity);
        var watchers = player.GetComponentsInChildren<IWatcher>();
        for(int i = 0; i < watchers.Length; i++)
        {
            if (watchers[i] is PlayerMovement)
                _watcher = watchers[i];
        }
        _services.GetService<SaveLoadService>().Load();
        
    }

    public void Save(PersistentData persistentData)
    {
        _watcher.Save(persistentData);
    }

    public void Load(PersistentData persistentData)
    {
        _watcher.Load(persistentData);
    }
}
