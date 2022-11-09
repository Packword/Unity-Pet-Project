using UnityEngine;
using Assets.CodeBase.Core;

internal class PlayerSaving: MonoBehaviour
{
    private InputService _inputService;
    private SaveLoadService _saveLoadService;
    private readonly Extensions _services = Extensions.Instance;

    private void Start()
    {
        _inputService = _services.GetService<InputService>();
        _saveLoadService = _services.GetService<SaveLoadService>();
    }

    private void Update()
    {
        if (HasInput())
            Save();
    }

    private bool HasInput()
    {
        return _inputService.IsSaveButtonClicked();
    }

    private void Save()
    {
        _saveLoadService.Save();
    }
}
