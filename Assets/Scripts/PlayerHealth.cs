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
    private Rigidbody2D rb;
    void Start()
    {
        healthSlider.maxValue = healthAmount;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthSlider.value = healthAmount;
        UpdateHealthBar();
    }

   


    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        StartCoroutine(UpdateHealthBar());

        if (healthAmount <= 0)
        {
            Die();
        }
    }
    //Function for the player taking damage
    IEnumerator UpdateHealthBar()
    {
        float elapsedTime = 0f;
        float duration = 0.5f;  

        while (elapsedTime < duration)
        {
            healthSlider.value = Mathf.Lerp(healthSlider.value, healthAmount, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        healthSlider.value = healthAmount;
    }
    //Updates the healthbar



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.CompareTag("Spikes")) || (collision.gameObject.CompareTag("SpikeMan")) || (collision.gameObject.CompareTag("Bottom")) || collision.gameObject.CompareTag("Enemy")) 
        {
            TakeDamage(10f);
        }
    }
    //Takes damage when colliding with the tags named above
    private void Die()
    {
        anim.SetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Static;
    }
}
//Animates the death





