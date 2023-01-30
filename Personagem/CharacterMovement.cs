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
        Physics();
        CharacterMovement();      
    }
    
    void Physics(){
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundedDistance);
        
        Vector3 desiredVelocity = new Vector3(moveX, 0, moveZ) * moveSpeed;
        
        rb.AddForce(desiredVelocity - rb.velocity, ForceMode.VelocityChange);
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
    }
    
    void CharacterMovement(){
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical"); 
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
