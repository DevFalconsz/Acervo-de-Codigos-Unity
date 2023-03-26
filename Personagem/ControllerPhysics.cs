using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPhysics : MonoBehaviour
{
    private Animator anim;
    
    private Vector3 enterInputs;

    private CharacterController charactererController;

    public Transform myCamera;

    private float velocidadeJogador = 4f;

    [SerializeField] private Transform footVerification;
    [SerializeField] private LayerMask sceneMask;
    private bool isFoot;

    [SerializeField] private float jumpHeight = 1f;
    private float gravity = -9.81f;
    private float velocityVertical;
    
    void Awake()
    {
        charactererController = GetComponent<CharacterController>();
    }
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Camera();
        Moviments();
    }

    void Moviments()
    {
        //Movimentation
        enterInputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        enterInputs = transform.TransformDirection(enterInputs);
        charactererController.Move(enterInputs * Time.deltaTime * velocidadeJogador);

        //Jump
        isFoot = Physics.CheckSphere(footVerification.position, 0.3f, sceneMask);

        if(Input.GetKeyDown(KeyCode.Space) && isFoot)
        {
            velocityVertical = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(isFoot && velocityVertical < 0)
        {
            velocityVertical = -1f;
        }

        velocityVertical += gravity * Time.deltaTime;

        charactererController.Move(new Vector3(0, velocityVertical, 0) * Time.deltaTime);

        //Mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Camera()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y, transform.eulerAngles.z);
    }

    void Animations()
    {

    }
}
