using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" || collision.tag != "BUllet")
        {
            //Debug.Log(collision.name);
            if (collision.tag == "Enemy")
            {
                Instantiate(Bleed, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else if(collision.tag == "Environment")
            {
                Instantiate(Impact, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            
        }

        
        
      
    }

  
}
