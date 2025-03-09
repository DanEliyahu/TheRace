using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private JoystickInput joystickInput;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    
    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    private Rigidbody2D rb;

    private float yRotation;
    private bool shouldJump;
    private bool isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        switch (joystickInput.Horizontal)
        {
            case > 0 when !isFacingRight:
            case < 0 when isFacingRight:
                Flip();
                break;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0,180,0);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(joystickInput.Horizontal * moveSpeed, rb.velocity.y);
        bool isGrounded = Physics2D.IsTouchingLayers(groundCheck, whatIsGround);
        if (isGrounded && shouldJump)
        {
            rb.AddForce(jumpForce * Vector2.up);
        }

        shouldJump = false;
    }

    public void Jump()
    {
        shouldJump = true;
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}