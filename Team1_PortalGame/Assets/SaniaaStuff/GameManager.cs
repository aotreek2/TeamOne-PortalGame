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
     private float damageTimer = 0f; //to check when the player last took damage
    public bool hasWon;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //redFlashImage.enabled = false;
        menuController.DisableEndGamePanel();
        healthTxt.text = "Health: " + playerHealth;
        playerHealth = 100;
        Time.timeScale = 1f;
        damageTimer = 0f;
    }


    

    public void TakeDamage()
    {
        playerHealth -= 15;
        healthTxt.text = "Health: " + playerHealth;
        Debug.Log("Player hit " + playerHealth);
        damageTimer = 0f; //resets the timer 
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

    private void RegainHealth(float amount)
    {
        playerHealth += amount;
        
        if (playerHealth > 100) //makes sure health doesnt go over 100
        {
            playerHealth = 100;
        }
        healthTxt.text = "Health: " + playerHealth;
        Debug.Log("Player regained health: " + playerHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if (damageTimer >= 5f) //regain health if you havent taken damage in x amount of secs
        {
            RegainHealth(15);
            damageTimer = 0f;
        }

          damageTimer += Time.deltaTime;


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
