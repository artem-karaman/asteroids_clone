using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private ObjectSpawner _playerSpawner;

    void Start()
    {
        _playerSpawner.CreateOrAdd();
    }
}
