using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject firePoint;
    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenShots <= 0)
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
