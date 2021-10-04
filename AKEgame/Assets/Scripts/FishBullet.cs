using UnityEngine;

public class FishBullet : MonoBehaviour
{
    public float speed;
    
    private void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        if (collision.GetComponent<ShootingFish>())
            collision.GetComponent<ShootingFish>().Action();

        Destroy(gameObject);
    }
}
