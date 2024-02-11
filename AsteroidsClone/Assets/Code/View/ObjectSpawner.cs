using UnityEngine;

[CreateAssetMenu(menuName ="Asteroids/Create Object Spawner",
    fileName ="ObjectSpawner")]
public class ObjectSpawner : ScriptableObject
{
    [SerializeField]
    private GameObject _objectToSpawn;

    public GameObject currentObject;

    //TODO: write object pooling for creation and optimization
    public GameObject CreateOrAdd()
    {
        currentObject =  Instantiate(_objectToSpawn);
        return currentObject;
    }
}
