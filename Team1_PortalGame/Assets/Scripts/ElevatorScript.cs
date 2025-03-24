using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] private Animator elevatorAnim;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            elevatorAnim.Play("ElevatorAnim");
        }
    }
}
