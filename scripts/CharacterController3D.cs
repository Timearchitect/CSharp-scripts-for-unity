using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    CharacterController controller;
    public float speed = 6.0f;
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    private Vector2 moveInput;
    private Vector3 velocity;
    private bool isGrounded;
    //private bool isJumping;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

    

        //easy :) 
        Vector3 move = transform.right * h + transform.forward * v;
        velocity += move * speed * Time.deltaTime;
  

        // Ground check
        if (controller.isGrounded)
        {
            isGrounded = true;
            velocity.y += gravity * 0.1f;
        }
       
        /* if (isGrounded && velocity.y < 0)
             velocity.y = -2f; // Small push to keep grounded
        */           
 

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
       
        controller.Move(velocity * Time.deltaTime); // gravition
        if (isGrounded && Input.GetButton("Jump"))
            Jump();
        
    }
    void Jump()
    {
            isGrounded = false;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }


   /* void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        controls.Player.Jump.performed += ctx => Jump();
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void Update()
    {
        // Ground check
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f; // Small push to keep grounded

        // Movement input
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = transform.TransformDirection(move);
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

  */
}
