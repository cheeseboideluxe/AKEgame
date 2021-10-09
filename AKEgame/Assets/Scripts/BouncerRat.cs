using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BouncerRat : MonoBehaviour
{
    float moveSpeed = 5f;
    Rigidbody2D rb;
    private Transform player;
    public static bool isAttacking = false;
    Animator anim;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        
        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3((float)-0.4578898, (float)0.4434159, 1);
        }
        else
        {
            transform.localScale = new Vector3((float)0.4578898, (float)0.4434159, 1);
        }
        if (isAttacking)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
    }

    void FixedUpdate()
    {
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            SoundManager.PlaySound("Death_BouncerRat");
            Destroy(col.gameObject, 3f);
            Destroy(gameObject);
        }
    }
}
