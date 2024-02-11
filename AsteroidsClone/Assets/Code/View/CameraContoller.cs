using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField]
    private ScreenSettings _screenSettings;

    [SerializeField]
    private Camera _mainCamera;

    void Start()
    {
        _screenSettings.BottomCenterPosition =
            _mainCamera.ScreenToWorldPoint(
                new Vector2(_mainCamera.pixelWidth / 2, 0)
            );
    }
}
