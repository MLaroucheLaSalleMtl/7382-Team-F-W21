using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour
{
    private bool isRageActive = false;
    private float rage;
    public float rageBar = 60f;
    [SerializeField] private float rageDrainPerSecond = 6f;
    [SerializeField] private float newSpeed = 8f;
    private health healthCache;
    private Movement movementCache;
    private Weapon weaponCache;
    
    [SerializeField] private float newGunDamage = 60f;


    private void Start()
    {
        healthCache = GetComponent<health>();
        movementCache = GetComponent<Movement>();
        weaponCache = GetComponent<Weapon>();
    }
    private void Update()
    {
        if (isRageActive)
        {
            rage -= Mathf.Clamp(Time.deltaTime * rageDrainPerSecond, 0, rageBar);
            if (rage <= 0)
            {
                DeactivateRage();
            }

        }


    }
    public void IncrementRage(int value)
    {

        if (isRageActive)
        {
            return;
        }

        rage += value;

        if (rage >= rageBar)
        {
            ActivateRage();

        }
        
    }

    void ActivateRage()
    {
        isRageActive = true;
        movementCache.UpdateSpeed(newSpeed);
        healthCache.Heal(healthCache._maxHealth);
        healthCache.Shield();
        weaponCache.UpdateGunDamage(newGunDamage);
        
        
    }

    void DeactivateRage()
    {
        isRageActive = false;
        movementCache.ResetSpeed();
        weaponCache.ResetGunDamage();
    }

    public float GetRage()
    {
        return rage;
    }
}
