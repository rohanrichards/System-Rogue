using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingController : MonoBehaviour
{
    private CharacterMouseInput mouseInput;
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        mouseInput = GetComponent<CharacterMouseInput>();
        inventoryManager = GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if we have a target 
        GameObject target = mouseInput.GetRayTarget();
        if (target)
        {
            // check if its harvestable
            ResourceNodeManager resourceManager = target.GetComponent<ResourceNodeManager>();
            if (resourceManager)
            {
                // harvest it and then remove it from the target tracker
                resourceManager.HarvestResource(inventoryManager);
                mouseInput.ClearRayTarget();
            }
        }
    }
}
