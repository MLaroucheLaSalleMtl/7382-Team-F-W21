using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    [SerializeField] private float _restoreHealth = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInChildren<health>().Heal(_restoreHealth);
            Destroy(this);
        }
    }
}
