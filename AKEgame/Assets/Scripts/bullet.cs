using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float moveSpeed = 7f;

    Rigidbody2D rb;
    PlayerControls target;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerControls>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 39f);

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
     
        if (col.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit!");
            
        }
    }
}
