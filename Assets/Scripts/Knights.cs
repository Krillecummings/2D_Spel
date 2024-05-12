using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knights : MonoBehaviour
{
    public float attackDistance = 3f;
    public float attackInterval = 1f;
    public int attackDamage = 10;

    private Animator anim;


    private GameObject Player;
    private bool isAttacking = false;
    private float lastAttackTime;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2.Distance(transform.position,Player.transform.position) < 3f))
        {
            anim.SetBool("close", true);
        }
        else
        {
            anim.SetBool("close", false);
        }





        if (isAttacking && Time.time - lastAttackTime > attackInterval)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            isAttacking = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            isAttacking = false;
        }
    }
    void Attack()
    {
   
        PlayerHealth playerHealth = Player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}