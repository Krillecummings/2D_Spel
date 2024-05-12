using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemymovement : MonoBehaviour
{
    private float dirX;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private GameObject[] waypoints;
    private Transform waypointTransform;
    [SerializeField] private float speed = 5f;



    private int currentWaypointIndex = 0;
    private float MaxHP = 10;
    private float HP = 10;
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
        MaxHP = HP;

    }

    // Update is called once per frame
    void Update()
    {
        waypointTransform = waypoints[currentWaypointIndex].transform;
        if(gameObject.name == "Little Knight")
        {
            Debug.Log(waypointTransform.position);
            Debug.Log(transform.position);

        }
        if (Vector2.Distance(waypointTransform.position, transform.position) < .1f)
        {

            currentWaypointIndex++;
            sprite.flipX = false;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                sprite.flipX = true;
                

            }

        }


        if (gameObject.name == "Little Knight")
        {

            Debug.Log(transform.position);
            transform.position = Vector2.MoveTowards(transform.position, waypointTransform.position, Time.deltaTime * speed);
        }
        transform.position = Vector2.MoveTowards(transform.position, waypointTransform.position, Time.deltaTime * speed);
   

    }
}
