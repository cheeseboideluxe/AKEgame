using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;

    public GameObject fishLeft, fishRight;
    Vector2 fishPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            SoundManager.PlaySound("Jump_MM");
            rb.AddForce(Vector2.up * 1000f);
        }

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);           

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            SoundManager.PlaySound("Attack1_MM");
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    void fire ()
    {
        fishPos = transform.position;
        if (facingRight)
        {
            fishPos += new Vector2(+2f, -0.15f);
            Instantiate(fishRight, fishPos, Quaternion.identity);
        }
        else
        {
            fishPos += new Vector2(-2f, -0.15f);
            Instantiate(fishLeft, fishPos, Quaternion.identity);
        }

        
    }
}
