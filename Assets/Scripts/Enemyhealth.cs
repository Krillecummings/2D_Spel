using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 30;
    int currentHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth; // Initialize currentHealth with maxHealth
    }
    
    public void Takedamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("Isdead", true);

        // Disable the collider and script
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    void Update()
    {
        // You can add update logic here if needed
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
