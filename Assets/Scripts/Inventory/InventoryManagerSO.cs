using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Manager", menuName = "Inventory/Inventory Manager")]
[System.Serializable]
public class InventoryManagerSO : ScriptableObject
{
    public static int inventorySize = 100;
    public InventoryItemSO[] items = new InventoryItemSO[inventorySize];

    public void AddItem(InventoryItemSO item)
    {
        int index = FindEmptySlot();
        if (index >= 0)
        {
            items[index] = item;
        }
    }

    int FindEmptySlot()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (items[i] == null)
            {
                return i;
            }
        }
        return -1;
    }
}
