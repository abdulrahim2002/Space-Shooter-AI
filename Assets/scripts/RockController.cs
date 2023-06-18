//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RockController : MonoBehaviour
//{
//    public float speed = 3f; // Speed of the rock movement

//    void Update()
//    {
//        Move();
//    }

//    public void Move()
//    {
//        transform.Translate(Vector3.left * speed * Time.deltaTime);

//        if (transform.position.x < -10f)
//        {
//            Destroy(gameObject);
//        }
//    }
//}



using UnityEngine;

public class RockController : MonoBehaviour
{
    public float speed = 3f; // Speed of the rock movement

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
