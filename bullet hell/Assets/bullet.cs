using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.Find("Player");
        direction = player.transform.position - transform.position;
        direction = direction.normalized;

        rb.AddForce(direction * speed, ForceMode2D.Impulse);


    }

    
}
