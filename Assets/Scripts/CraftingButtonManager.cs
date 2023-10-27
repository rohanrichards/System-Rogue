using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingButtonManager : MonoBehaviour
{
    public CraftingRecipeSO recipe;
    public InventoryManagerSO inventory;
    public PlayerCraftingManager craftingManager;
    private Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = "Craft " + recipe.producedItem.name;

        gameObject.GetComponent<Button>().onClick.AddListener(TryCraftItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TryCraftItem()
    {
        craftingManager.CraftTool(recipe);
    }
}
