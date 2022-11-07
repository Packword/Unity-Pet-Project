using UnityEngine;
using Assets.CodeBase.Core;

internal class InputService: IService
{
    private Vector3 _inputVector = Vector3.zero;

    public Vector3 InputVector {
        get {
            _inputVector.x = Input.GetAxis("Horizontal");
            _inputVector.z = Input.GetAxis("Vertical");

            return _inputVector;
        }
    }

    public Vector3 MousePosition 
        => Input.mousePosition;

    public bool IsHorizontalOrVerticalButtonPressed
        => Input.GetButton("Horizontal") || Input.GetButton("Vertical");

    public bool IsJumpButtonPressed 
        => Input.GetButtonDown("Jump");

    public bool IsShootButtonClicked() 
        => Input.GetMouseButtonDown(0);
}
