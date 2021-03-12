using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private int _lives = 3;


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

    public void UpdateLives()
    {
        
        _lives--;
        if (_lives < 0)
        {
            //GameOver();
        }
    }
}
