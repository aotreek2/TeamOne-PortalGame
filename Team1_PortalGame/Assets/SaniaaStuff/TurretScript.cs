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
       idleMode = true;
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            Debug.Log("Button is pressed");
        }

        if (other.CompareTag("TestPlayer")) 

         {
            Debug.Log("Target within range");
            attackMode = true; 
            idleMode = false; 
         }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TestPlayer")) 
        {
            Debug.Log("Target out of range");
            attackMode = false; 
            idleMode = true; 
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackMode = !attackMode;
            idleMode = !attackMode; 
           
        }

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
        if (Time.time >= fireIntervals)
        {
           
            Shoot();

            fireIntervals = Time.time + fireRate;
        }
    }

     void Shoot()
    {
        
        if (bulletPrefab && bulletSpawnPoint)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            Destroy(bulletPrefab, 5f); //destroys bullet after 5 seconds
        }
    }
}
