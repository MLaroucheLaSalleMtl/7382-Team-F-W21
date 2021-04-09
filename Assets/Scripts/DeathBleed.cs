using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBleed : MonoBehaviour
{
    public Animator deathBleed;
    // Start is called before the first frame update
    void Start()
    {
        deathBleed.SetBool("isBleeding", true);
    }

    
}
