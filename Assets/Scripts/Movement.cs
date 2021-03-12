using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool movement = false;
    [SerializeField] private float speed = 4f;
    public Animator walkAnimation;

    void Start()
    {
        walkAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
        
            walkAnimation.SetBool("isMoving", true);
        
            
        
    }

   
    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed; 
    }


    private void PlayerMovement()
    {
        
        if(Input.GetKey(KeyCode.W))
        {
            
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            movement = true;
            
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);           
            movement = true;
            
        } 
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);           
            movement = true;
            

        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            movement = true;
            
        }
        else
        {
            movement = false;

            walkAnimation.SetBool("isMoving", false);
        }
    }
}
