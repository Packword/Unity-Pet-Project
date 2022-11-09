using UnityEngine;
using Assets.CodeBase.Core;

public partial class FactoryHero: IService
{
    private readonly GameObject _heroPrefab;
    private readonly Extensions _services = Extensions.Instance;
    private SaveLoadService _saveLoadService;
    private Player _player;


    public FactoryHero(GameObject hero)
    { 
        _heroPrefab = hero;
    }

    public void BuildHero(Vector3 at) 
    {
        GameObject player = GameObject.Instantiate(_heroPrefab, at, Quaternion.identity);
        _player = new Player();
        _services.GetService<SaveLoadService>().Load();

        player.transform.position = _player.Position;
    }

    public void Save(PersistentData persistentData)
    {
        _player.Save(persistentData);   
    }

    public void Load(PersistentData persistentData)
    {
        _player.Load(persistentData);
    }
}
