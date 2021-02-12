using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private int _lives = 3;
    private float _currentHealth;
    private bool _isDead = false;
    private bool isShielded = false;
    

    // Start is called before the first frame update
    void Start()
    {
        MainCharacter();
    }

    private void MainCharacter()
    {
        _currentHealth = _maxHealth;
        _isDead = false;
        _lives = 3;
        isShielded = false;
    }

    private void Die()
    {
        _isDead = true;
        _lives--;
    }

    public void TakeDamage(int damage)
    {
        if (isShielded)
        {
            damage = 0;
            isShielded = false;

        }

        _currentHealth -= damage;

        if (_currentHealth <= 0 && !_isDead)
            Die();
        return;
        
    }

   public void Heal()
    {
        _currentHealth = _maxHealth;
    }

    public void Shield()
    {

    }
}
