using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerSettings _playerSettings;
    [SerializeField]
    private ScreenSettings _screenSettings;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform
            .Translate(
                _playerSettings.InstantSpeed * Time.fixedDeltaTime * Vector3.up
            );
    }

    void OnBecameInvisible()
    {
        Debug.Log("Entered method called: OnBecameInvisible");
        transform.position = _screenSettings.BottomCenterPosition;
    }
}
