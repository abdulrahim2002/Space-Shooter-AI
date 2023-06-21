using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    private float scrollSpeed = GameManager.scrollBackgroundSpeed; // Speed of the scrolling
    private float instantiateX = -10f; // X coordinate at which to destroy the background
    private float destroyX = -28f; // X coordinate at which to generate the background
    private Vector3 respawnPosition = new Vector3(24f, 0f, 2f); // Position to respawn the background

    private bool newadded;
    private bool isScrolling;

    private void Start()
    {
        StartCoroutine(UpdateBackgroundScrollSpeed());
        StartCoroutine(CheckPositionAndScrollCondition());

        isScrolling = true;
        newadded = false;
    }

    void Update()
    {
        if (isScrolling)
        {
            // Scroll the background towards the left
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
    }

    private IEnumerator UpdateBackgroundScrollSpeed()
    {
        while (true)
        {
            // Update the enemySpeed value every 2 seconds
            scrollSpeed = GameManager.scrollBackgroundSpeed;
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator CheckPositionAndScrollCondition()
    {
        while (true)
        {
            if (transform.position.x <= instantiateX && !newadded)
            {
                // Instantiate a new background
                GameObject backgroundGenerated = Instantiate(gameObject, respawnPosition, Quaternion.identity);
                if (gameObject.name == "Background")
                    backgroundGenerated.name = "Background1";
                else
                    backgroundGenerated.name = "Background";

                newadded = true;
            }

            // Check if the background has gone beyond the destroyX coordinate
            if (transform.position.x <= destroyX)
            {
                // Destroy the current background instance
                Destroy(gameObject);
            }

            isScrolling = GameManager.isRunning;

            yield return new WaitForSeconds(0.5f);
        }
    }
}