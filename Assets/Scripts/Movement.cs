using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed;
    public float speed = 4f;
    private float speedBase;


    void Start()
    {
        
        
        
        //walkAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position = new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;




    }

   
    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed; 
    }

    public void ResetSpeed()
    {
        speed = speedBase;
    }
   
}
