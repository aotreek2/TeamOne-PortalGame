using UnityEngine;

public class OpenFinalDoor : MonoBehaviour
{

    [SerializeField] private Animator finalDoorAnimator;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            finalDoorAnimator.Play("door_2_open");
        }
    }
}
