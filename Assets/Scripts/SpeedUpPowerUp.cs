using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPowerUp : MonoBehaviour
{
    [SerializeField] private float _speedUp = 8f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponentInChildren<Movement>().UpdateSpeed(_speedUp);
            Destroy(this);
        }
    }

}
