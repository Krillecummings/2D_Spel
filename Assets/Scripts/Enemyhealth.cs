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
        currentHealth = maxHealth; 
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

        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    void Update()
    {
       
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
