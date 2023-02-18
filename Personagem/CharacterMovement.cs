using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class MovementCharacterer : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = true;

    private Rigidbody rb;

    public CinemachineFreeLook virtualCamera;

    public GameObject player;

    private Renderer rendererMaterial;

    public Material playerMaterial;
    public Material caughtMaterial;

    void Start()
    {
        rendererMaterial = GetComponent<Renderer>();
        virtualCamera = GetComponentInChildren<CinemachineFreeLook>();

        if(isLocalPlayer){
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = new Vector3(0, -0.5f, 0);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(!isLocalPlayer){
            virtualCamera.gameObject.SetActive(false);
        }else{
            virtualCamera.gameObject.SetActive(true);
        }
    }

    void Update(){
        if(gameObject.tag == "Caught"){
            rendererMaterial.material = caughtMaterial;
        }
        if(gameObject.tag == "Player"){
            rendererMaterial.material = playerMaterial;
        }
        if(Input.GetKeyDown(KeyCode.M)){
            Vector3 newRotation = new Vector3(0f, 0f, 0f);
            player.transform.rotation = Quaternion.Euler(newRotation);
            rb.Sleep();
        }
    }

    void FixedUpdate()
    {
        if(isLocalPlayer){
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && isLocalPlayer)
        {
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Vector3 repulsionDirection = transform.position - other.transform.position;
            rb.AddForce(repulsionDirection.normalized * 10f, ForceMode.Impulse);
        }
    }
}
