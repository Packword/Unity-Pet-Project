using UnityEngine;
using Assets.CodeBase.Core;

public class MainCamera
{
    private Camera _camera;
    private Ray _cameraRay;
    private InputService _inputService;
    private Extensions _services = Extensions.Instance;

    public MainCamera()
    {
        _inputService = _services.GetService<InputService>();
        _camera = Camera.main;
    }

    public Ray GetCameraRayToMousePosition()
    {
        _cameraRay = _camera.ScreenPointToRay(_inputService.MousePosition);

        return _cameraRay;
    }
}
