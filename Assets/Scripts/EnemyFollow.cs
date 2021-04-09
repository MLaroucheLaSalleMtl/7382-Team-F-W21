using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float smooth = 0.0f;
    public float speed;
    public float stoppingDistance;
    public float agroDistance;
    public float retreatDistance;  

    private Transform target;
    private Transform enemy;

    public Vector3 direction;
    public Rigidbody2D rb;
    public RaycastHit2D hit;

    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        Look();
        Follow();
    }

    // Update is called once per frame
    void Update()
    {

        //Follow();
        Look();
            
    }
            
        
    void Follow()
    {
        
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
           
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
           
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            rb.rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        }
    }

    void Look()
    {

        direction = target.position - transform.position;

        //This line gets the position of the target and converts it to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {

           
            //rb.rotation = angle;

           
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            //transform.position = this.transform.position;
            rb.rotation = angle;
            
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {

            
            rb.rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

           

        }
    }
           
}


  

