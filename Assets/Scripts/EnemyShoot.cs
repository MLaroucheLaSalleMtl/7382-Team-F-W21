using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    //public float shootingRange;

    public GameObject firePoint;
    public GameObject projectile;
    public GameObject player;

    //private RaycastHit2D hit;
    private float originOffset = 1f;


    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        Debug.DrawRay(transform.position, transform.right, Color.green);
        
        if (hit.collider.tag == "Player")
            Shooting();
        


    }

    void Shooting()
    {
        if (timeBetweenShots <= 0)
        {

            Instantiate(projectile, firePoint.transform.position, transform.rotation);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

   
}
