using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerRat : MonoBehaviour
{
    float dirX;
    [SerializeField]
    float moveSpeed = 3f;
    Rigidbody2D rb;

    bool facingRight = false;
    Vector3 localScale;

    public static bool isAttacking = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        if (transform.position.x < -9f)
            dirX = 1f;
        else if (transform.position.x > 9f)
            dirX = -1f;

        if (isAttacking)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
        this.transform.position += transform.up * Time.deltaTime * moveSpeed;
    }

    void FixedUpdate()
    {
        if (!isAttacking)
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = false;
        else if (dirX < 0)
            facingRight = true;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject, 15f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("turnpoint"))

        {
            return;
        }
        this.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90);
    }
}
