using UnityEngine;
using Assets.CodeBase.Core;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed;

    private readonly Extensions _services = Extensions.Instance;
    private InputService _inputService;


    private void Start()
        => _inputService = _services.GetService<InputService>();

    private void Update()
    {
        Vector3 inputVector = GetInputVector();
        if (HasInput())
            Run(inputVector);
    }

    private bool HasInput() 
        => _inputService.IsHorizontalOrVerticalButtonPressed;

    private void Run(Vector3 inputVector)
        => MovePlayer(inputVector * _speed);

    private void MovePlayer(Vector3 movement) =>
        _characterController.Move(movement * Time.deltaTime);

    private Vector3 GetInputVector() =>
        _inputService.InputVector;
}
