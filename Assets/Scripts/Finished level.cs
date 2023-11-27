using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishedlevel : MonoBehaviour

{
    public Animator anim;
    private AudioSource finishSound;
    private bool levelCompleted;
    
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && levelCompleted != true)
        {
            anim.SetTrigger("finished");
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 6f);
            
        }
    }
    void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
