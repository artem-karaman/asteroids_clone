using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ObjectSpawner _playerSpawner;
    void Start()
    {
        _playerSpawner.CreateOrAdd();
    }
}
