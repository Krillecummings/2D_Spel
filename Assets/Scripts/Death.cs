using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Death : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update

    [SerializeField] private AudioSource deathSoundEffect;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hej");
        if ((collision.gameObject.CompareTag("Spikes")) || (collision.gameObject.CompareTag("SpikeMan")) || (collision.gameObject.CompareTag("Bottom")))
        {
            Debug.Log(collision.gameObject.name);
            Die();

        }

    }
    private void Die()
    {
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        
    }

    private void RestartLive()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
     

    

