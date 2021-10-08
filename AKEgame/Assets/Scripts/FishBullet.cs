using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBullet : MonoBehaviour
{
    public float dirX;
    float dirY = 0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject, 3f);
            Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

}
