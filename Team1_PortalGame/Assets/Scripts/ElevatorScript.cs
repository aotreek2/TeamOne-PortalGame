using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] private Animator elevatorAnim;
    [SerializeField] private AudioSource openSFX, closeSFX;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            elevatorAnim.Play("ElevatorAnim");
        }
    }
}
