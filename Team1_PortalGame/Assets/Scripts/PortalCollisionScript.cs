using UnityEngine;


//////////////////////////////////////////////
//Assignment/Lab/Project: Portal Project
//Name: Kristen Holcombe
//Section: SGD285.4173
//Instructor: Ven Lewis
//Date: 03/3/2025
////////////////////////////////////////////

public class PortalCollisionScript : MonoBehaviour
{

    //set target in the Portal's trigger box. 

    private Transform target;

    //for accessing portalScript where target is set.
    private PortalScript portalScript;

    private void Awake()
    {
        portalScript = GetComponentInParent<PortalScript>();

        if(portalScript.target == null)
        {
            print("set target in inspector of Portal trigger box!");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        print("entered collider");
        if(other.gameObject.CompareTag("Player"))
        {
            //print("player entered collider");
            //print("target.transform.position is " + target.transform.position);

            

            other.transform.position = portalScript.target.transform.position;
            other.transform.rotation = portalScript.target.transform.rotation;
            Physics.SyncTransforms();

           //print("position changed");
        }
    }
}
