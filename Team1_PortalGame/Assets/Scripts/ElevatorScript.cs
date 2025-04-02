using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] private Animator elevatorAnim;
    [SerializeField] private AudioSource openSFX, closeSFX;
    [SerializeField] private Animator door1Animator;
    

    private void Start()
    {
    }

    public void PlayOpenSFX()
    {
        openSFX.Play();
        
    }

    public void PlayCloseSFX()
    {
        closeSFX.Play();
    }

    public void OpenDoors()
    {
        door1Animator.Play("door_2_open");
        print("played door open");
    }

    public void CloseDoors()
    {
        door1Animator.Play("door_2_close");
        print("play door close");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            elevatorAnim.Play("ElevatorAnim");
        }
    }

}
