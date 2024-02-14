using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerSettings _playerSettings;
    [SerializeField]
    private ScreenSettings _screenSettings;

    [SerializeField]
    private InputActionReference _moveAction;
    [SerializeField]
    private InputActionReference _shootAction;
    [SerializeField]
    private InputActionReference _rotateAction;

    private void OnEnable()
    {
        _moveAction.action.Enable();
        _moveAction.action.performed += OnMoveAction;

        _rotateAction.action.Enable();
        _rotateAction.action.performed += OnRotateAction;
    }

    private void OnRotateAction(InputAction.CallbackContext context)
    {
        transform.Rotate(transform.position,
            Vector3.Angle(transform.position,
            context.ReadValue<Vector2>()));
    }

    private void OnMoveAction(InputAction.CallbackContext context)
    {
       transform
            .Translate(
                _playerSettings.InstantSpeed *
                Time.fixedDeltaTime *
                Vector2.up);
    }

    private void OnDisable()
    {
        _moveAction.action.Disable();
        _rotateAction.action.Disable();
    }

    void OnBecameInvisible()
    {
        Debug.Log("Entered method called: OnBecameInvisible");
        transform.position = _screenSettings.BottomCenterPosition;
    }
}
