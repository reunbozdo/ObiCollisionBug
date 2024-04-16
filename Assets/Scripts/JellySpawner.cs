using System;
using System.Collections.Generic;
using Obi;
using UnityEngine;

public class JellySpawner : MonoBehaviour
{
    [SerializeField] Transform jellyParent;
    [SerializeField] ObiSolver solver;

    public List<JellyObject> spawnedObjects = new();

    int instances = 0;

    public void Spawn(JellyObject prefab, Vector3 position, Quaternion rotation, Action<JellyObject> OnSpawn = null)
    {
        instances++;
        int id = instances;

        JellyObject jelly = Instantiate(prefab, position, rotation);
        jelly.transform.SetParent(jellyParent);

        spawnedObjects.Add(jelly);

        OnSpawn?.Invoke(jelly);
    }


    public void Destroy(JellyObject jelly, Action OnComplete)
    {
        Destroy(jelly.gameObject);
        OnComplete?.Invoke();
    }
}
