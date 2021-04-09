using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private int _lives = 3;
    private GameObject[] enemies;
    private int _score = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        GetEnemies();
        Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        player.GetComponent<health>().MainCharacter();
        player.transform.position = _startPoint.transform.position;
    }

    public void UpdateLives(int delta)
    {
        _lives += delta;

        if (_lives < 0)
        {
            //GameOver();
        }
    }

    private void GetEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        print(enemies);
    }

    private void Subscribe()
    {
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().onEnemyDie += IncrementRage;
            enemy.GetComponent<EnemyHealth>().onEnemyDie += IncrementScore;

        }
    }

    private void IncrementScore()
    {
        _score += 100;
    }

    private void IncrementRage()
    {
        player.GetComponent<Rage>().IncrementRage(10);
    }
}
