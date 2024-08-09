using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerSettings _playerSettings;
    [SerializeField]
    private ScreenSettings _screenSettings;

    public float GasForce = 0.05f; // сила газа
    public float StopForce = -2f; // сила торможения
    public float SpeedLimit = 0.1f; // ограничение скорости
    public float _inertionDamping = 0.99f;

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

    void OnBecameInvisible()
    {
        Debug.Log("Entered method called: OnBecameInvisible");
        transform.position = _screenSettings.BottomCenterPosition;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        Debug.Log($"Получаю значение ввода равного = {value}");
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        var value =context.ReadValue<Vector2>();
        Debug.Log($"Получаю значение ввода равного = {value}");
    }
}
