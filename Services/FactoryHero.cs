using UnityEngine;
using Assets.CodeBase.Core;

public class FactoryHero: IService
{
    private readonly GameObject _heroPrefab;

    public FactoryHero(GameObject hero)
        => _heroPrefab = hero;

    public GameObject BuildHero(Vector3 at)
        => GameObject.Instantiate(_heroPrefab, at, Quaternion.identity);
}
