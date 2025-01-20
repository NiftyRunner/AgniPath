using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class DynamicNavCreator : MonoBehaviour
{
    NavMeshSurface surface;

    void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
    }

    void Update()
    {
        surface.BuildNavMesh();            
    }
}
