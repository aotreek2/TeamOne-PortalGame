using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float playerHealth;
    [SerializeField] private TMP_Text healthTxt;
    public Image redFlashImage; //flash image for when the player gets hit
    public float flashDuration = 0.5f;
    public float fallDamage = 0f;
    [SerializeField] private MenuController menuController;
    [SerializeField] private PlayerMovement playerMovement;
    public bool hasWon;


    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //redFlashImage.enabled = false;
        menuController.DisableEndGamePanel();
        healthTxt.text = "Health: " + playerHealth;
        playerHealth = 100;
        Time.timeScale = 1f;
        // redFlashImage = GameObject.Find("RedFlash").GetComponent<Image>();
    }


    

    public void TakeDamage()
    {
        playerHealth -= 15;
        healthTxt.text = "Health: " + playerHealth;
        Debug.Log("Player hit " + playerHealth);
        StartCoroutine(FlashRedScreen());
    }

    public void TakeFallDamage(float damage)
    {
        playerHealth -= damage;
        healthTxt.text = "Health: " + playerHealth;
        StartCoroutine(FlashRedScreen());
    }

    public void Death()
    {
        menuController.EnableEndGamePanel();
        menuController.outcomeTxt.text = "You Died!";
        Debug.Log("Player has Died");
        //playerMovement.RespawnAtCheckpoint();
    }

    public void Win()
    {
        menuController.EnableEndGamePanel();
        menuController.outcomeTxt.text = "You Won!";
        Debug.Log("Player has Died");
        //playerMovement.RespawnAtCheckpoint();
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
       if (playerHealth <= 0)
        {
            Death();
        }
        else if(hasWon == true)
        {
            Win();
        }

    }
}
