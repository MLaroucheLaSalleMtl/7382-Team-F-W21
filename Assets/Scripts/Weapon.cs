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
    private float shootForce = 5f;

    public float meleeDamage = 50f;
    [SerializeField] private float gunDamageBase = 28f;
    public float gunDamage;

    [SerializeField] private AudioSource[] _audioSource;

    void Start()
    {
        gunDamage = gunDamageBase;
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
        rb.AddForce(shotPoint.up * shootForce, ForceMode2D.Force);

    }

    void MouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 10f, Color.red);
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

    public void UpdateGunDamage(float newDamage)
    {
        gunDamage = newDamage;
    }

    public void ResetGunDamage()
    {
        gunDamage = gunDamageBase;
    }


}
