using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishedlevel : MonoBehaviour

{
    public Animator anim;
    private AudioSource finishSound;
    private int enemycount = 5;
    private bool levelCompleted;
    
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    /*void Update()
    {
        if(  && levelCompleted != true)
        {
            anim.SetTrigger("finished");
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 6f);
            
        }
    }*/
    void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
