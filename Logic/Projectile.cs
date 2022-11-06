using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public LayerMask IgnoredLayersMask;

    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceCheck = 0.15f;

    void Update()
    {
        Ray projectileRay = new Ray(transform.position, transform.forward);

        if (IsRayHitObject(projectileRay, out RaycastHit hit))
        {
            GameObject.Instantiate(_particlePrefab, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject.Destroy(gameObject);
        }

        UpdatePosition();
    }

    private bool IsRayHitObject(Ray ray, out RaycastHit hit)
    {
        return Physics.Raycast(ray, out hit, _distanceCheck, ~IgnoredLayersMask) == true;
    }

    private void UpdatePosition()
    {
        transform.position += Direction * _speed * Time.deltaTime;
    }
}
