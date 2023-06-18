using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet movement

    void Start()
    {
        //Destroy(gameObject, destroyDelay);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        //destroy the bullet if it moves beyond -10f in x
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    // Check if the bullet collides with any other object
    //    // Example: if (other.CompareTag("Player")) { ... }
    //    // Replace "Player" with the appropriate tag for your player object

    //    Destroy(gameObject); // Destroy the bullet on collision
    //}
}
