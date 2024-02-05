using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int maxHealth = 30;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Takedamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
    }
    void Update()
    {
        
    }
}
