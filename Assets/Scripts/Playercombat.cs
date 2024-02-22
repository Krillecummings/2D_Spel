using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playercombat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public Transform attackPoint;

    public Animator animator;

    public float attackRange = 0.5f;

    public int attackDamage = 100;

    public float attackRate = 2f;

    float nextAttackTime = 0f;

    public LayerMask enemyLayers;
    void Update()
    {
        if(Time.time >=  nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Attack();
                nextAttackTime = Time.time + 1f/ attackRate;
            }
        }
    }
      
    void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);



        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemyhealth>().Takedamage(attackDamage);

            Debug.Log("Träff");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null) 
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}