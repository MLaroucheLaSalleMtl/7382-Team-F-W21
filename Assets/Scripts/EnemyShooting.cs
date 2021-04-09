using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public GameObject Impact;
    public GameObject Bleed;

    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = transform.right * speed;

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //    if(collision.collider.tag == "Player")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    

    void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.tag != "Enemy") // || collision.tag != "Bullet")
      {

            if (collision.tag == "Player")
            {
                Instantiate(Bleed, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else if (collision.tag == "Environment") 
           {
               Instantiate(Impact, transform.position, transform.rotation);
               Destroy(gameObject);
          }

     }




    }
}
