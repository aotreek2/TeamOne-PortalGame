using UnityEngine;

public class PortalScript : MonoBehaviour
{

    //set target in the Portal's trigger box. 

    [SerializeField]
    public Transform target;


    private void Awake()
    {

        if(target == null)
        {
            print("set target for portal!");
        }
    }
}
