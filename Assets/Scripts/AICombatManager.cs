using CMF;
using Polarith.AI.Move;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombatManager : MonoBehaviour
{
    private GameObject target;
    public float targetingRange = 10f;
    public float attackingRange = 2f;
    public float windupLength = 1f;
    private bool inWindup = false;
    public float windupMoveSpeed = 1;
    private float previousMoveSpeed;
    public int damage = 10;

    private SensorToolkitWalkerController walkController;

    // Start is called before the first frame update
    void Start()
    {
        walkController = GetComponent<SensorToolkitWalkerController>();
        previousMoveSpeed = walkController.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // is there a target nearby?
        CheckForTarget(targetingRange);
        if(target)
        {
            // is it within attack range?
            if(Vector3.Distance(transform.position, target.transform.position) < attackingRange)
            {
                // enter into a windup state
                if(!inWindup)
                {
                    Debug.Log("Target in range entering windup");
                    StartCoroutine(BeginWindup());
                }
            }
        }
    }

    private void CheckForTarget(float range)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Player")
            {
                target = hitColliders[i].gameObject;
                break;
            }
            else
            {
                target = null;
            }
        }
    }

    IEnumerator BeginWindup()
    {
        inWindup = true;
        walkController.movementSpeed = windupMoveSpeed;
        // queue the attack on the target
        yield return new WaitForSeconds(windupLength);
        AttackTarget();
    }

    void AttackTarget()
    {
        inWindup = false;
        walkController.movementSpeed = previousMoveSpeed;
        CheckForTarget(attackingRange);
        Debug.Log("Attacking Target: " + target);
        if(target)
        {
            Debug.Log("Hit Target!");
            target.GetComponent<AttributeManager>().ApplyDamage(damage);
        }else
        {
            Debug.Log("Miss!");
        }
    }
}
