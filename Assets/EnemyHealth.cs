using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 100.0f;


    public GameObject deathBleed;

    public HealthBarScript healthBar;
    public Canvas canvas;
    public Animator enemyDeathAnimation;
    public EnemyFollow followScript;

    // Start is called before the first frame update
    void Start()
    {
        deathBleed.SetActive(false);
        enemyDeathAnimation = GetComponent<Animator>();
        health = maxHealth;
        healthBar.SetMaxHelth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            canvas.gameObject.SetActive(true);
            health -= 28.0f;
            healthBar.SetHealth(health);
        }
        if (collision.tag == "MeleeHit")
        {
            Debug.Log("IS HITTTT !!!!!!");
            canvas.gameObject.SetActive(true);
            health -= 50f;
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {
            enemyDeathAnimation.SetBool("isDead", true);
            deathBleed.SetActive(true);
            canvas.gameObject.SetActive(false);
            
            StartCoroutine(DeyingProcess());

            
        }

    }

    IEnumerator DeyingProcess()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
    
