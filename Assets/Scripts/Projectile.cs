using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 15;
    [SerializeField] private float spinSpeed = 360;
    [SerializeField] private float lifeTime = 3;
    
    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        rb.angularVelocity = spinSpeed;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
