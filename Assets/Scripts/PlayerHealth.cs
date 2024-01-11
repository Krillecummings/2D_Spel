using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthbar;
    private float healthAmount = 100f;
    public Slider healthSlider;
    private Animator anim;
    void Start()
    {
        healthSlider.maxValue = healthAmount;
        healthSlider.value = healthAmount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        healthSlider.value = healthAmount;

        
        if (healthAmount <= 0)
        {
            Die();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.CompareTag("Spikes")) || (collision.gameObject.CompareTag("SpikeMan")) || (collision.gameObject.CompareTag("Bottom")) || collision.gameObject.CompareTag("Enemy"));

        takeDamage(10f);


    }
    private void Die()
    {
        anim.SetTrigger("death");
    }
}


