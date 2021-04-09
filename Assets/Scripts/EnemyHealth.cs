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

    //Disabling enemy componenets
    public EnemyFollow followScript;
    private EnemyShoot shootScript;

    public delegate void OnEnemyDie();
    public OnEnemyDie onEnemyDie;

    private Weapon player;

    private bool _isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>();
        
        deathBleed.SetActive(false);
        
        enemyDeathAnimation = GetComponent<Animator>();
        followScript = GetComponent<EnemyFollow>();
        shootScript = GetComponent<EnemyShoot>();

        health = maxHealth;
        healthBar.SetMaxHelth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isDead)
        {
            return;
        }

        if (collision.tag == "Bullet")
        {
            canvas.gameObject.SetActive(true);
            health -= player.gunDamage;
            healthBar.SetHealth(health);
        }
        if (collision.tag == "MeleeHit")
        {
            //Debug.Log("IS HITTTT !!!!!!");
            canvas.gameObject.SetActive(true);
            health -= player.meleeDamage;
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {
            _isDead = true;
            enemyDeathAnimation.SetBool("isDead", true);
            deathBleed.SetActive(true);
            canvas.gameObject.SetActive(false);

            followScript.enabled = false;
            shootScript.enabled = false;
            
            StartCoroutine("DyingProcess");
            onEnemyDie();

        }

    }

   

    IEnumerator DyingProcess()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
    
