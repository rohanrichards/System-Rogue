using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Item")]
public class InventoryItemSO : ScriptableObject
{
    public string title;
    public string description;
    public Sprite artwork;
    public bool isStackable;
    public bool isEquippable;
}
