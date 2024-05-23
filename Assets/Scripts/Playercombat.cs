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

    public int attackDamage = 50;

    public float attackRate = 2f;

    float nextAttackTime = 0f;

    public LayerMask enemyLayers;
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                Attack2();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                Attack3();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }
    //Attack buttons
    private void Attack2()
    {
        animator.SetTrigger("Attack2");
    }

    private void Attack3()
    {
        animator.SetTrigger("Attack3");
    }
    void Attack()
    {
        animator.SetTrigger("Attack1");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);



        if (hitEnemies.Length > 0)
        {
            foreach (Collider2D Enemy in hitEnemies)
            {
                if (Enemy.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("skadar");
                    Enemy.GetComponent<Enemyhealth>().Takedamage(attackDamage);
                }

            }
        }
    }
    //Enemies taking damage
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null) 
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void Hurt()
    {
        animator.SetTrigger("Hurt");
    }

}