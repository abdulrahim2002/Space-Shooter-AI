using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 2.5f; // Speed of the enemy movement
    public float shootInterval = 2f; // Time interval between enemy bullet spawns
    public GameObject enemyBulletPrefab; // Reference to the enemy bullet prefab
    
    private float shootTimer = 0f;

    void Update()
    {
        Move();
        Shoot();
    }

    public void Move()
    {
        transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            InstantiateEnemyBullet();
            shootTimer = 0f;
        }
    }

    private void InstantiateEnemyBullet()
    {
        // Instantiate the enemy bullet at the spaceship's position
        GameObject enemyBullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);

        // Optional: Set the bullet's direction or additional properties
        // Example:
        // EnemyBullet bulletScript = enemyBullet.GetComponent<EnemyBullet>();
        // if (bulletScript != null)
        // {
        //     bulletScript.SetDirection(Vector3.left);
        // }
    }

}

    