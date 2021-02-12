using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPowerUp : MonoBehaviour
{
    [SerializeField] private float _speedUp = 6f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        collision.GetComponent<Movement>().UpdateSpeed(_speedUp);
        Destroy(this);
    }

}
