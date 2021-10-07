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
    private bool isCrouching = false;
    public GameObject fishLeft, fishRight;
    Vector2 fishPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    public float baseSpeed;
    public float dashPower;
    public float dashTime;
    bool isDashing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = baseSpeed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 6f;

       
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

       if (Input.GetKeyDown(KeyCode.K))
        {
            if (!isDashing)
            {
                StartCoroutine(Dash());
            }
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
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Trolley"))
        {
            anim.Play("_isDead");
            Destroy(gameObject, 0.5f);

        } 
        
    }

    IEnumerator Dash()
    {
        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("isDashing", true);
        else
            anim.SetBool("isDashing", false);


        isDashing = true;
        var dashSpeed = baseSpeed;
        dashSpeed *= dashPower;
        moveSpeed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        moveSpeed = baseSpeed;
        isDashing = false;
        

    }
}
