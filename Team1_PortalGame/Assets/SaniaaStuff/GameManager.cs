using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public float playerHealth = 100;
    public Image redFlashImage; //flash image for when the player gets hit
    public float flashDuration = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redFlashImage.enabled = false;
         //redFlashImage = GameObject.Find("RedFlash").GetComponent<Image>();
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Bullet"))
    {
        playerHealth -= 15;
        Debug.Log("Player hit " + playerHealth);
        StartCoroutine(FlashRedScreen());
    }
}

private IEnumerator FlashRedScreen()
    {
        
        redFlashImage.enabled = true;
        yield return new WaitForSeconds(flashDuration);
        redFlashImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
