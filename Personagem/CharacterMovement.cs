using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 10.0f;
    public float groundedDistance = 0.2f;
    public float gravity = -9.81f;
    
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

        // Get input for horizontal and vertical movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate the desired velocity
        Vector3 desiredVelocity = new Vector3(moveX, 0, moveZ) * moveSpeed;

        // Apply the desired velocity
        rb.AddForce(desiredVelocity - rb.velocity, ForceMode.VelocityChange);

        // Check if the jump button is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply upward force for jumping
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Apply gravity
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
    }
}
