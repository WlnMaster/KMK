using UnityEngine;

public class JumpWithJumpCount : MonoBehaviour
{
    public float jumpForce = 5.0f; // Adjust the jump force as needed
    public int maxJumpCount = 1;   // Set the maximum jump count
    private int currentJumpCount = 0;
    public bool isJumping;
    private Rigidbody2D rb;
    private Collider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Perform the jump when the spacebar is pressed and within the jump count limit
        if (Input.GetKeyDown(KeyCode.Space) && currentJumpCount < maxJumpCount && !isJumping)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply an upward force to the Rigidbody to make the GameObject jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        currentJumpCount++;
    }

    void FixedUpdate()
    {
        // Check if the GameObject is grounded
        isJumping = !coll.IsTouchingLayers(LayerMask.GetMask("Floor"));
        if (!isJumping)
        {
            currentJumpCount = 0; // Reset jump count when grounded
        }
    }
}
