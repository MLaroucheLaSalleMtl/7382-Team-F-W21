using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float _maxHealth = 100;
    
    [SerializeField] private float _currentHealth;
    private bool _isDead = false;
    private bool isShielded = false;
    

    // Start is called before the first frame update
    void Start()
    {
        MainCharacter();
    }

    public void MainCharacter()
    {
        _currentHealth = _maxHealth;
        _isDead = false;
        isShielded = false;
    }

    private void Die()
    {
        _isDead = true;
        if (gameObject.CompareTag("Player"))
               GameManager.instance.UpdateLives(-1);
            
        
    }

    public void TakeDamage(int damage)
    {
        if(_isDead)
        {
            return;
        }

        if (isShielded)
        {
            damage = 0;
            isShielded = false;
            return;
        }

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (_currentHealth <= 0 && !_isDead)
        {
            Die();
            Heal(_maxHealth);
            GameManager.instance.SpawnPlayer();
            
        }
        return;
        
    }

   public void Heal(float newHealth)
    {
        _currentHealth = newHealth;
    }

    public void Shield()
    {
        isShielded = true;
    }

    public bool GetIsDead()
    {
        return _isDead;
    }
}
