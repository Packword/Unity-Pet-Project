using UnityEngine;
using Assets.CodeBase.Core;

public class PlayerShooting : MonoBehaviour
{
    public GameObject _projectilePrefab;

    [SerializeField] private Transform _gunPoint;
    [SerializeField] private LayerMask _ignoredLayersMask;

    private readonly Extensions _services = Extensions.Instance;
    private InputService _inputService;
    private FactoryProjectile _factoryProjectile;

    private void Start()
    {
        _inputService = _services.GetService<InputService>();
        _factoryProjectile = _services.GetService<FactoryProjectile>();
    }

    private void Update()
    {
        if (HasInput())
            ShootWithDebug();
    }

    private bool HasInput() 
        => _inputService.IsShootButtonClicked();

    private void ShootWithDebug()
    {
        MainCamera mainCam = new MainCamera();
        Ray cameraRay = mainCam.GetCameraRayToMousePosition();

        if (IsRayHitObject(cameraRay, out RaycastHit hit))
            ReleaseProjectile(hit);
    }

    private bool IsRayHitObject(Ray ray, out RaycastHit hit)
    {
        float distanceCheck = 1000f;
        return Physics.Raycast(ray, out hit, distanceCheck, ~_ignoredLayersMask);
    }

    private void ReleaseProjectile(RaycastHit hit)
    {
        Vector3 direction = ComputeNormalizedDirection(hit);
        DrowDebugRay(direction);

        CreateProjectile(hit, direction);
    }

    private Vector3 ComputeNormalizedDirection(RaycastHit hit)
        => (hit.point - _gunPoint.position).normalized;

    private void DrowDebugRay(Vector3 direction)
    {
        float debugDuration = 4.0f;
        Debug.DrawRay(_gunPoint.position, direction, Color.green, debugDuration);
    }

    private void CreateProjectile(RaycastHit hit, Vector3 direction)
    {
        _factoryProjectile.BuildProjectile(_gunPoint.position, hit.point, direction);
    }
}
