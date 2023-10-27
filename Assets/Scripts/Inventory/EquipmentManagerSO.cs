using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Manager", menuName = "Inventory/Equipment Manager")]
public class EquipmentManagerSO : ScriptableObject {
    public ToolSO[] slots = new ToolSO[5];
    private ToolSO selected;

    public void SetItem(int position, ToolSO item)
    {
        slots[position] = item;
    }

    public void SelectItem(int index)
    {
        selected = slots[index];
    }

    public ToolSO GetSelected()
    {
        return selected;
    }
}
