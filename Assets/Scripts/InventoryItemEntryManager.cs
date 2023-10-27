using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InventoryItemEntryManager : MonoBehaviour
{
    public InventoryItemSO item;
    public new TextMeshProUGUI name;
    private GameObject icon;

    // Start is called before the first frame update
    void Awake()
    {
        name = GetComponentInChildren<TextMeshProUGUI>();
        icon = GameObject.Find("ItemIcon");
    }

    // Update is called once per frame
    void Update()
    {
        if (item)
        {
            name.SetText(item.title);
        }
    }
}
