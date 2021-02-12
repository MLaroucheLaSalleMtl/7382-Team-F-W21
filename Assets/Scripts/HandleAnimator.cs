using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimator : MonoBehaviour
{

    private Animator animator;
    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isWalking = true;
            animator.SetTrigger("isWalking");
        }
    }
}
