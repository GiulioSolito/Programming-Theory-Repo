using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal
{
    [SerializeField] private List<GameObject> _foodPatches = new List<GameObject>();

    protected override void Start()
    {
        base.Start();
        AssignFoodPatches();
        ChooseFoodPatch();
    }

    void AssignFoodPatches()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("FoodPatch");

        for (int i = 0; i < g.Length; i++)
        {
            _foodPatches.Add(g[i]);
        }
    }

    void ChooseFoodPatch()
    {
        Transform target = _foodPatches[Random.Range(0, _foodPatches.Count)].transform;
        transform.LookAt(target);
    }
}
