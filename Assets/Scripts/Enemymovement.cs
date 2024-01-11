using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    private float dirX;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private GameObject[] waypoints;
    private Transform waypointTransform;
    private int currentWaypointIndex = 0;
    private int HP = 10;
    private int Edamage = 10;
    private int enemycount = 5;
    private int points = 0;
    [SerializeField] private TextMeshProUGUI Enemycount;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;

    }

    // Update is called once per frame
    void Update()
    {
        waypointTransform = waypoints[currentWaypointIndex].transform;
        if (Vector2.Distance(waypointTransform.position, transform.position) < .1f)
        {

            Debug.Log(currentWaypointIndex);
            currentWaypointIndex++;
            sprite.flipX = false;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                sprite.flipX = true;

            }
        }
        if (HP<0)
        {
            Destroy(sprite.gameObject);
            points += 1;

            Enemycount.text = "Enemies Remaining: " + points;

            enemycount++;
        }


    }
}
