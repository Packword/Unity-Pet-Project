using UnityEngine;
using Assets.CodeBase.Core;

internal class FactoryProjectile: IService
{
    private readonly GameObject _projectilePrefab;

    public FactoryProjectile(GameObject projectile)
        => _projectilePrefab = projectile;

    public void BuildProjectile(Vector3 at, Vector3 destination, Vector3 direction)
    { 
        GameObject projectile = GameObject.Instantiate(_projectilePrefab, at, Quaternion.identity);
        projectile.transform.LookAt(destination);
        projectile.GetComponent<Projectile>().Direction = direction;
    }
}
