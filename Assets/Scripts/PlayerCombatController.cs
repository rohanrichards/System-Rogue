using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    private CharacterMouseInput mouseController;
    public int damage = 12;
    // Start is called before the first frame update
    void Start()
    {
        mouseController = GetComponent<CharacterMouseInput>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = mouseController.GetSphereTarget();
        if (target)
        {
            target.GetComponent<AttributeManager>().ApplyDamage(damage);
            mouseController.ClearSphereTarget();
        }
    }
}
