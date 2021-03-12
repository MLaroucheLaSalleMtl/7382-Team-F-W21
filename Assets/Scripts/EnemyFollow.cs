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
    

    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
          
        
    }

    // Update is called once per frame
    void Update()
    {


        direction = target.position - transform.position;

        //This line gets the position of the target and converts it to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        Debug.DrawRay(transform.position, target.position, Color.green);

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rb.rotation = angle;

            //transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, -rotationSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            rb.rotation = angle;
            //transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, target.position, rotationSpeed * Time.deltaTime, 0f));
        }
        else if(Vector2.Distance(transform.position, target.position) < retreatDistance) //&& Vector2.Distance(transform.position, enemy.position) > retreatDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            rb.rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

            //transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, target.position, rotationSpeed * Time.deltaTime, 0f));

        }
                
    }
            
        
           
}


  

