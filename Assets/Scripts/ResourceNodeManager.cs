using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNodeManager : MonoBehaviour
{
    public ResourceSO resource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HarvestResource(InventoryManager harvesterInventory)
    {
        /*
         * Need to determine how much of the resource the player should get (depends on tool/skills/chance)
         * Need to make sure the user is using the correct tool
         * Give the plaayer the resource
         * Determine if the node is depleted and should be destroyed
         */
        harvesterInventory.AddItem(resource.provides);
        Destroy(gameObject);
    }
}
