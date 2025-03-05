using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
   ///publics

    public GameObject bulletPrefab;
    public bool attackMode;
    public bool idleMode;
    public Transform bulletSpawnPoint; //where the bullet will come from 
    public float fireRate = 1f; //how fast the turret will shoot 
    
    //privates

    private float fireIntervals = 0f; // time inbetween each shot

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            Debug.Log("Button is pressed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(idleMode == true)
        {
            Debug.Log("Turrets are looking around");
            attackMode = false; 

        }
        if(attackMode == true)
        {
            Debug.Log("Turrets are firing at the player");
            idleMode = false; 
            Fire();
        }

    
    }

     void Fire()
    {
        if (Time.time >= nextFireTime)
        {
           
            Shoot();

            nextFireTime = Time.time + fireRate;
        }
    }

     void Shoot()
    {
        
        if (bulletPrefab && bulletSpawnPoint)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}
