using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Inventory/Tool")]
public class ToolSO : InventoryItemSO
{
    public int maxDurability = 100;
    public int currentDurability = 100;
}
