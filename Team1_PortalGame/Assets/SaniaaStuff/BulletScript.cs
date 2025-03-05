using UnityEngine;

public class BulletScript : MonoBehaviour
{

     public float speed = 10f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
