using System;
using System.Collections.Generic;
using Obi;
using UnityEngine;

public class JellySplitController : MonoBehaviour
{
    [SerializeField] ObiObjectClicker obiObjectClicker;
    [SerializeField] JellySpawner jellySpawner;

    private void Awake()
    {
        obiObjectClicker.OnObiActorClick += ObiObjectClicker_OnObiActorClick;
    }

    private void OnDestroy()
    {
        obiObjectClicker.OnObiActorClick -= ObiObjectClicker_OnObiActorClick;
    }

    private void ObiObjectClicker_OnObiActorClick(ObiActor actor)
    {
        if (actor.TryGetComponent<JellyObject>(out var jellyObject))
        {
            Split(jellyObject);
        }
    }

    private void Split(JellyObject jellyObject)
    {
        if (jellyObject.splitInto == null) return;

        List<Vector3> points = new();
        List<Quaternion> rots = new();

        jellyObject.splitJellyPoints.ForEach(x => points.Add(x.position));
        jellyObject.splitJellyPoints.ForEach(x => rots.Add(x.rotation));

        JellyObject prefab = jellyObject.splitInto;

        jellySpawner.Destroy(jellyObject, null);

        for (int i = 0; i < points.Count; i++)
        {
            var rot = rots[i];
            var point = new Vector3(points[i].x, points[i].y, 0f);
            
            jellySpawner.Spawn(prefab, point, rot);
        }
    }
}