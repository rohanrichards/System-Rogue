using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCraftingManager : MonoBehaviour
{
    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CraftTool(CraftingRecipeSO recipe)
    {
        InventoryItemSO tool = (InventoryItemSO)recipe.createItem(inventoryManager.inventory);
        if (tool) {
            inventoryManager.AddItem(tool);
        }        
    }
}
