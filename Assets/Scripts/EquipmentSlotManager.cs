using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotManager : MonoBehaviour
{
    public int index = 0;
    public EquipmentManagerSO equipment;
    private Image icon;
    // Start is called before the first frame update
    void Awake()
    {
        icon = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (equipment.slots[index])
        {
            icon.sprite = equipment.slots[index].artwork;
        }
    }
}
