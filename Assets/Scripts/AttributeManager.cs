using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void HealDamage(int damage)
    {
        currentHealth += damage;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void CheckHealth()
    {
        if(currentHealth <=0)
        {
            Destroy(gameObject);
        }
    }
}
