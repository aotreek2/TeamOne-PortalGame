using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //publics 
     public float speed = 10f;
    // public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
      /*  if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.playerHealth -= 2f;
        } */
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.right * speed * Time.deltaTime);
       // Debug.Log(gameManager.playerHealth);
    }
}
