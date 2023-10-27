using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CMF
{
    public class UIManager : MonoBehaviour
    {
        public GameObject player;
        protected CharacterInput characterInput;
        public Canvas craftingCanvas;
        public Canvas inventoryCanvas;
        private InventoryManagerSO inventory;
        private InventoryManager inventoryManager;
        private EquipmentManagerSO equipment;
        public GameObject itemEntryPrefab;
        public GameObject inventoryScrollContent;
        private bool redraw = false;
        private GameObject[] itemEntrySlots;

        // Start is called before the first frame update
        void Start()
        {
            characterInput = player.GetComponent<CharacterInput>();
            inventoryManager = player.GetComponent<InventoryManager>();
            inventory = inventoryManager.inventory;
            equipment = player.GetComponent<EquipmentManager>().equipment;
            inventoryManager.inventoryChanged.AddListener(SetRedraw);
            itemEntrySlots = new GameObject[InventoryManagerSO.inventorySize];
            SetupInventory();
        }

        void SetRedraw()
        {
            redraw = true;
        }

        // Update is called once per frame
        void Update()
        {

            if (characterInput.IsInventoryKeyPressed())
            {
                if (craftingCanvas.enabled)
                {
                    craftingCanvas.enabled = false;
                }else
                {
                    craftingCanvas.enabled = true;
                }
            }

            if (redraw)
            {
                DrawInventory();
                redraw = false;
            }
        }

        void SetupInventory()
        {
            for(int i = 0; i < InventoryManagerSO.inventorySize; i++)
            {
                InventoryItemSO item = inventory.items[i];
                GameObject entry = Instantiate(itemEntryPrefab, inventoryScrollContent.transform);
                itemEntrySlots[i] = entry;

                if (item)
                {
                    entry.GetComponent<InventoryItemEntryManager>().item = item;
                }else
                {
                    entry.SetActive(false);
                }

                entry.GetComponentInChildren<TMP_Dropdown>().onValueChanged.AddListener(index => SetEquipmentSlot(index, entry.GetComponent<InventoryItemEntryManager>().item));
            }
        }

        void DrawInventory()
        {
            for (int i = 0; i < InventoryManagerSO.inventorySize; i++)
            {
                InventoryItemSO item = inventory.items[i];
                if (item)
                {
                    GameObject slot = itemEntrySlots[i];
                    slot.GetComponent<InventoryItemEntryManager>().item = item;
                    slot.SetActive(true);
                    slot.GetComponentInChildren<TMP_Dropdown>().onValueChanged.AddListener(index => SetEquipmentSlot(index, slot.GetComponent<InventoryItemEntryManager>().item));
                }else
                {
                    GameObject slot = itemEntrySlots[i];
                    slot.GetComponent<InventoryItemEntryManager>().item = null;
                    slot.SetActive(false);
                }
            }
        }

        void SetEquipmentSlot(int index, InventoryItemSO item)
        {
            Debug.Log("Setting new item into equipment slot " + index + " " + item);
            equipment.SetItem(index, (ToolSO)item);
        }
    }
}