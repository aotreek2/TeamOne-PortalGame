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
    public float rotateSpeed = 5f;
    //privates

    private float fireIntervals = 0f; // time inbetween each shot
    private Transform player; //getting player transform

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            Debug.Log("Button is pressed");
        }

        if (other.CompareTag("Player")) 

         {
            Debug.Log("Target within range");
            attackMode = true; 
            idleMode = false;
            player = other.transform;
         }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Target out of range");
            attackMode = false; 
            idleMode = true;
            player = null;
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
           // Debug.Log("Turrets are looking around");
            attackMode = false; 

        }
        if(attackMode == true)
        {
           // Debug.Log("Turrets are firing at the player");
            idleMode = false; 
            Fire();

            if (player != null)
            {
                TargetPlayer();
            }
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

    void TargetPlayer()
    {
        Vector3 direction = player.position - transform.position; //getting the target of the player 
        direction.y = 0;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);


    }
}
