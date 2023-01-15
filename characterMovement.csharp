using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 10.0f;
    public float groundedDistance = 0.2f;
    
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundedDistance);
        
        // Get input for horizontal movement
        float moveX = Input.GetAxis("Horizontal");
        // Apply horizontal movement
        rb.AddForce(transform.right * moveX * moveSpeed, ForceMode.VelocityChange);
        
        // Check if the jump button is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply upward force for jumping
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
