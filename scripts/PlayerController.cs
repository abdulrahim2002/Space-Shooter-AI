using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject gameManager;

    //update this variable after every 2 seconds
        private float playerSpeed = GameManager.playerSpeed; // Speed of the spaceship movement

        private float minY = -4.5f; // Minimum Y position (adjust according to camera boundary)
        private float maxY = 4.5f; // Maximum Y position (adjust according to camera boundary)

        private float shootInterval = 0.5f; // Time interval between player bullet spawns
        public GameObject playerBulletPrefab; // Reference to the player bullet prefab

        private float shootTimer = 0f;

    //Audio
    public AudioClip shootAudioClip;
    public AudioClip destroyAudioClip;

    private AudioSource audioSource;

    public void Start()
    {
        // Start the coroutine to update the playerSpeed every 2 seconds
        StartCoroutine(UpdatePlayerSpeed());

        audioSource = GetComponent<AudioSource>();

        gameManager = GameObject.Find("gamemanager");
    }

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
        float newYPosition = transform.position.y + (playerSpeed * Time.deltaTime);
        newYPosition = Mathf.Clamp(newYPosition, minY, maxY);

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

    public void MoveDown()
    {
        float newYPosition = transform.position.y - (playerSpeed * Time.deltaTime);
        newYPosition = Mathf.Clamp(newYPosition, minY, maxY);

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

    public void Shoot()
    {
        if (shootTimer >= shootInterval)
        {
            InstantiatePlayerBullet();
            // play audio
            if (audioSource != null && shootAudioClip != null)
            {
                audioSource.clip = destroyAudioClip;
                audioSource.Play();
            }


            shootTimer = 0f;
        }
    }

    private void InstantiatePlayerBullet()
    {
        // Instantiate the enemy bullet at the spaceship's position
        Instantiate(playerBulletPrefab, transform.position, Quaternion.identity);
    }

    public void PlayDestroySound()
    {
        // plays player killed audio
        if (audioSource != null && destroyAudioClip != null)
        {
            audioSource.clip = destroyAudioClip;
            audioSource.Play();
        }
    }

    private IEnumerator UpdatePlayerSpeed()
    {
        while (true)
        {
            // Update the playerSpeed value every 2 seconds
            playerSpeed = GameManager.playerSpeed;
            yield return new WaitForSeconds(2f);
        }
    }

    private IEnumerator Lag()
    {
        // Wait for the destroy sound to finish playing
        yield return new WaitForSeconds(destroyAudioClip.length);
    }

    private void OnTriggerEnter2D(Collider2D triggerCollidor)
    {
        // tags: enemyBullet, rock, villain
        if (triggerCollidor.tag == "enemyBullet")
        {
            Destroy(triggerCollidor.gameObject);
            //decrease health
            GameManager.playerHealth -= 1;       
            if (GameManager.playerHealth <= 0)
            {
                PlayDestroySound();
                StartCoroutine(Lag());
                Destroy(gameObject);

                GameManager script = gameManager.GetComponent<GameManager>();
                if (script != null)
                {
                    script.GameOver();
                }
                else
                {
                    Debug.Log("Fuck");
                }
            }

            //animation effect of being hit
            //play sound effect
        }

        if (triggerCollidor.tag == "rock")
        {
            Destroy(triggerCollidor.gameObject);
            PlayDestroySound();
            StartCoroutine(Lag());
            Destroy(gameObject);

            GameManager script = gameManager.GetComponent<GameManager>();
            if (script != null)
            {
                script.GameOver();
            }
            else
            {
                Debug.Log("Fuck");
            }
        }

        if (triggerCollidor.tag == "villain")
        {
            Destroy(triggerCollidor.gameObject);
            PlayDestroySound();
            StartCoroutine(Lag());
            Destroy(gameObject);

            GameManager script = gameManager.GetComponent<GameManager>();
            if (script != null)
            {
                script.GameOver();
            }
            else
            {
                Debug.Log("Fuck");
            }
        }

    }

}