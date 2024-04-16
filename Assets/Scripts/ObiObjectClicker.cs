using System;
using Obi;
using UnityEngine;

public class ObiObjectClicker : MonoBehaviour
{
    public event Action<ObiActor> OnObiActorClick;

    [SerializeField] ObiSolver solver;
    [SerializeField] float distance = 20f;
    [SerializeField] float rayThickness = 0.1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int filter = ObiUtils.MakeFilter(ObiUtils.CollideWithEverything, 0);

            if (solver.Raycast(ray, out QueryResult queryResult, filter, distance, rayThickness))
            {
                int i = solver.simplices[queryResult.simplexIndex];
                var qwe = solver.particleToActor[i];
                OnObiActorClick?.Invoke(qwe.actor);
            }
        }
    }
}
