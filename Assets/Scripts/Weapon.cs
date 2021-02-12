using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public float offset;
    

    public GameObject projectile;
    public Transform shotPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Shooting Logic
        Instantiate(projectile, shotPoint.position, shotPoint.rotation);

    }
}
