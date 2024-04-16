using UnityEngine;

public class DebugSpawner : MonoBehaviour
{
    [SerializeField] Transform point;
    [SerializeField] JellyObject prefab;
    [SerializeField] JellySpawner spawner;

    public void Spawn()
    {
        spawner.Spawn(prefab, point.position, point.rotation);
    }
}
