using UnityEngine;
using Assets.CodeBase.Core;
using System;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _jumpHeight = 5.0f;

    private readonly Extensions _services = Extensions.Instance;
    private InputService _inputService;
    private bool _isJumping = false;
    private Vector3 _verticalVelocity;

    private const float Gravity = -9.81f;

    private void Start()
    {
        _inputService = _services.GetService<InputService>();
        _verticalVelocity = Vector3.up * Gravity;
    }

    private void Update()
    {
        if (CanJump())
            Jump();

        ApplyGravity();
    }

    private bool CanJump()
        => _inputService.IsJumpButtonPressed && !(_isJumping);

    private void Jump()
    {
        _isJumping = true;
        _verticalVelocity.y += Mathf.Sqrt(_jumpHeight * -1.0f * Gravity);
    }

    private void ApplyGravity()
    {
        UpdateGravity();
        MovePlayer(_verticalVelocity);
    }

    private void UpdateGravity()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity.y = 0f;
            _isJumping = false;
        }
        else
            _verticalVelocity.y += GetVerticalChangePerFrame();
    }

    private float GetVerticalChangePerFrame()
        => Gravity * Time.deltaTime;

    private void MovePlayer(Vector3 movement) =>
        _characterController.Move(movement * Time.deltaTime);
}
