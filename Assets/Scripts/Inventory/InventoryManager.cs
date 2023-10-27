using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    public InventoryManagerSO inventory;
    public UnityEvent inventoryChanged;

    public void AddItem(InventoryItemSO item)
    {
        inventory.AddItem(item);
        inventoryChanged.Invoke();
    }
}
