using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a resource node in the world
public class ResourceSO : ScriptableObject
{
    public InventoryItemSO provides;
    public GameObject prefab;
    public int weight = 1;
}
