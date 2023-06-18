using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Speed of the spaceship movement
    public float minY = -4.5f; // Minimum Y position (adjust according to camera boundary)
    public float maxY = 4.5f; // Maximum Y position (adjust according to camera boundary)

    //shoot functionality
    public float shootInterval = 0.2f; // Time interval between enemy bullet spawns
    public GameObject playerBulletPrefab; // Reference to the enemy bullet prefab

    private float shootTimer = 0f;

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void MoveUp()
    {
        float newYPosition = transform.position.y + (speed * Time.deltaTime);
        newYPosition = Mathf.Clamp(newYPosition, minY, maxY);

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

    public void MoveDown()
    {
        float newYPosition = transform.position.y - (speed * Time.deltaTime);
        newYPosition = Mathf.Clamp(newYPosition, minY, maxY);

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

    public void Shoot()
    {
        if (shootTimer >= shootInterval)
        {
            InstantiatePlayerBullet();
            shootTimer = 0f;
        }
    }

    private void InstantiatePlayerBullet()
    {
        // Instantiate the enemy bullet at the spaceship's position
        GameObject playerBullet = Instantiate(playerBulletPrefab, transform.position, Quaternion.identity);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hi");
        // Check if the collision involves a rock or enemy ship
        if (collision.gameObject.CompareTag("rock") || collision.gameObject.CompareTag("villain"))
        {
            //game over, destroy the player and return score etc.
            Debug.Log("Player was hit!");
            Destroy(gameObject);

        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        isJumping = false;
    //    }
    //}


}