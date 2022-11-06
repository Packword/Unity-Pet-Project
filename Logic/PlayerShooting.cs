using UnityEngine;
using Assets.CodeBase.Core;

public partial class PlayerShooting : MonoBehaviour
{
    public GameObject _projectilePrefab;

    [SerializeField] private Transform _gunPoint;
    [SerializeField] private LayerMask _ignoredLayersMask;

    private Extensions _services = Extensions.Instance;
    private InputService _inputService;
    void Start()
    {
        _inputService = _services.GetService<InputService>();
    }

    void Update()
    {
        if (_inputService.IsShootButtonClicked())
        {
            MainCamera mainCam = new MainCamera();
            Ray cameraRay = mainCam.GetCameraRayToMousePosition();

            if (IsRayHitObject(cameraRay, out RaycastHit hit))
            {
                Vector3 direction = ComputeNormalizedDirection(hit);
                DrowDebugRay(direction);

                CreateProjectile(hit, direction);
            }
        }
    }

    private void CreateProjectile(RaycastHit hit, Vector3 direction)
    {
        GameObject projectile = Instantiate(_projectilePrefab, _gunPoint.position, Quaternion.identity);
        projectile.transform.LookAt(hit.point);
        projectile.GetComponent<Projectile>().Direction = direction;
    }

    private bool IsRayHitObject(Ray ray, out RaycastHit hit)
    {
        float distanceCheck = 1000f;
        return Physics.Raycast(ray, out hit, distanceCheck, ~_ignoredLayersMask);
    }

    private void DrowDebugRay(Vector3 direction)
    {
        float debugDuration = 4.0f;
        Debug.DrawRay(_gunPoint.position, direction, Color.green, debugDuration);
    }

    private Vector3 ComputeNormalizedDirection(RaycastHit hit)
    {
        return (hit.point - _gunPoint.position).normalized;
    }

}
