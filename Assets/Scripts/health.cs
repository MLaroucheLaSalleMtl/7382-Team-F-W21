using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    
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
        if (gameObject.tag == "Player") ;
               GameManager.instance.UpdateLives();
            
        
    }

    public void TakeDamage(int damage)
    {
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
            Heal();
            GameManager.instance.SpawnPlayer();
            
        }
        return;
        
    }

   public void Heal()
    {
        _currentHealth = _maxHealth;
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
