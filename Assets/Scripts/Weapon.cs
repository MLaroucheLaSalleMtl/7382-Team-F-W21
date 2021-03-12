using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public float offset;
    

    public GameObject projectile;
    public GameObject meleeRange;

    public Transform shotPoint;
    public Animator meleeAnimation;
    public Animator shootAnimation;
    public float shootForce = 5f;

    [SerializeField] private AudioSource[] _audioSource;

    void Start()
    {
        meleeAnimation = GetComponent<Animator>();
        shootAnimation = GetComponent<Animator>();
        meleeRange.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
       
    }

    void Shoot()
    {
        //Shooting Logic
        GameObject bullet = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        //GameObject splash = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint.up * shootForce, ForceMode2D.Impulse);

    }

    void MouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootAnimation.SetTrigger("isFiring");
            Shoot();
            _audioSource[0].Play();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {   
            
            meleeAnimation.SetTrigger("isMelee");
            meleeRange.SetActive(true);
            _audioSource[1].Play();
            StartCoroutine(MeleeTime());




        }
    }

    IEnumerator MeleeTime()
    {
        yield return new WaitForSeconds(1.5f);
        meleeRange.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
