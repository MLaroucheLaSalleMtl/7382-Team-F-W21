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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            
            if (collision.tag == "Player")
            {
                Instantiate(Bleed, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(Impact, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }




    }
}
