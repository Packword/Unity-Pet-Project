using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public LayerMask IgnoredLayersMask;

    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceCheck = 0.15f;

    private void Update()
    {
        Ray projectileRay = new Ray(transform.position, transform.forward);

        if (IsRayHitObject(projectileRay, out RaycastHit hit))
            DestroyProjectileWithParticles(hit);

        UpdatePosition();
    }

    private bool IsRayHitObject(Ray ray, out RaycastHit hit)
        => Physics.Raycast(ray, out hit, _distanceCheck, ~IgnoredLayersMask) == true;

    private void DestroyProjectileWithParticles(RaycastHit hit)
    {
        GameObject.Instantiate(_particlePrefab, hit.point, Quaternion.LookRotation(hit.normal));
        GameObject.Destroy(gameObject);
    }

    private void UpdatePosition()
        => transform.position += Direction * _speed * Time.deltaTime;
}
