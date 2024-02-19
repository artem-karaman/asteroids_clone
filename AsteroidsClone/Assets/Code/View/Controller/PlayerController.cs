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

    public float GasForce = 0.05f; // сила газа
    public float StopForce = -2f; // сила торможения
    public float SpeedLimit = 0.1f; // ограничение скорости
    public float _inertionDamping = 0.99f;

    private void OnEnable()
    {
        _moveAction.action.Enable();
        _moveAction.action.performed += OnMoveAction;

        _rotateAction.action.Enable();
        _rotateAction.action.performed += OnRotateAction;
    }

    private void OnRotateAction(InputAction.CallbackContext context)
    {

    }

    private void OnMoveAction(InputAction.CallbackContext context)
    {
        // transform.position += transform.up * Time.deltaTime * _playerSettings.InstantSpeed;
    }

    void FixedUpdate()
    {
        _playerSettings.InstantSpeed = Mathf.Clamp(_playerSettings.InstantSpeed + (Input.GetAxis("Vertical") > 0 ? Input.GetAxis("Vertical") : StopForce) * GasForce * Time.fixedDeltaTime, 0, 1);

        _playerSettings.Inertia += transform.up * Input.GetAxis("Vertical") * _playerSettings.InstantSpeed * Time.fixedDeltaTime;
        _playerSettings.Inertia = Vector3.ClampMagnitude(_playerSettings.Inertia, SpeedLimit);


        _playerSettings.Inertia *= _inertionDamping;
        _playerSettings.CurrentSpeed = 
        Mathf.Sqrt(Mathf.Pow(_playerSettings.Inertia.x, 2) + Mathf.Pow(_playerSettings.Inertia.y, 2));

        transform.Rotate(Vector3.forward, Input.GetAxis("Horizontal") * -1f);
        transform.Translate(_playerSettings.Inertia, Space.World);
    }

    private void OnDisable()
    {
        _moveAction.action.performed -= OnMoveAction;
        _moveAction.action.Disable();

        _rotateAction.action.performed -= OnRotateAction;
        _rotateAction.action.Disable();
    }

    void OnBecameInvisible()
    {
        Debug.Log("Entered method called: OnBecameInvisible");
        transform.position = _screenSettings.BottomCenterPosition;
    }
}
