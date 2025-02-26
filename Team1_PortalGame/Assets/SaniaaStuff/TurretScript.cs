using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public GameObject bulletPrefab;
    public bool attackMode;
    public bool idleMode;

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
        }

        
  
    }
}
