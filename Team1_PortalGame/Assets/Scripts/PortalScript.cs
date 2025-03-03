using UnityEngine;

public class PortalScript : MonoBehaviour
{

    //set target in the Portal's trigger box. 

    [SerializeField]
    private Transform target;

    private void Start()
    {
        if(target == null)
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

            

            other.transform.position = target.transform.position;
            Physics.SyncTransforms();

           //print("position changed");
        }
    }
}
