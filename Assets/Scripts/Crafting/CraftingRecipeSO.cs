using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "Crafting/Recipe")]
public class CraftingRecipeSO : ScriptableObject
{
    public List<InventoryItemSO> requiredItems;
    public ToolSO producedItem;

    public ToolSO createItem(InventoryManagerSO inventory)
    {
        //check if the inventory has the required items in it, then remove them
        if (checkForRequirements(inventory))
        {
            // make the new thing and then return it
            //removeRequirements(inventory);
            ToolSO toolAsset = (ToolSO)UnityEngine.Object.Instantiate(producedItem);
            Debug.Log("Crafting new tool: " + producedItem);
            return toolAsset;
        }else
        {
            Debug.Log("Did not have required items to craft");
            return null;
        }        
    }

    private bool checkForRequirements(InventoryManagerSO inventory)
    {
        bool found = true;
        for(int i=0; i<requiredItems.Count; i++)
        {
            InventoryItemSO requiredItem = requiredItems[i];
            if (!Array.Exists<InventoryItemSO>(inventory.items, item => item == requiredItem))
            {
                found = false;
                break;
            }
        }
        return found;
    }

    private void removeRequirements(InventoryManagerSO inventory)
    {
        for (int i = 0; i < requiredItems.Count; i++)
        {
            InventoryItemSO requiredItem = requiredItems[i];
            //InventoryItemSO itenInInventory = inventory.items.Find(item => item == requiredItem);
            //inventory.items.Remove(itenInInventory);
        }
    }
}
