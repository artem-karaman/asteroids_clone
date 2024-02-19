using UnityEngine;

[CreateAssetMenu(menuName ="Asteroids/Player settings", fileName ="PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public float InstantSpeed;

    public Vector3 Inertia;

    public float CurrentSpeed;
}
