using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    //publics 
     public float speed = 10f;
     private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.TakeDamage();
            Debug.Log("Player has taken damage");
        } 
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.right * speed * Time.deltaTime);
       // Debug.Log(gameManager.playerHealth);
    }
}
