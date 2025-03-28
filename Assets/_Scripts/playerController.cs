using System;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private Vector2 moveInput;
    private bool jumpPressed = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform spriteTransform;

    [field: SerializeField] public float moveSpeed { get; private set; } = 5f;
    [field: SerializeField] public float jumpForce { get; private set; } = 5f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    // [SerializeField] private float groundCheckOffset = 0.5f;


    void Awake()
    {
        inputActions = new InputSystem_Actions();
        getComposents();
        enablePlayerControl();
    }

    void Update()
    {
        applyMovement();
        handleAnimation();
    }

    void FixedUpdate()
    {
        if(jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            jumpPressed = false;
        }
    }

    private void applyMovement()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, 0) * (moveSpeed * Time.deltaTime);
        transform.position += movement;

        if (moveInput.x > 0)
            transform.localScale = new Vector3(10, 10, 1);
        else if (moveInput.x < 0)
            transform.localScale = new Vector3(-10, 10, 1);
    }

    private void handleAnimation()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));
        animator.SetBool("isJumping", jumpPressed);
        animator.SetBool("isGrounded", isGrounded());
    }

    void OnEnable()
    {
        //Movement
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        inputActions.Player.Jump.performed += ctx => jumpPressed = isGrounded();
        enablePlayerControl();
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnDisable()
    {
        inputActions.Player.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
        inputActions.Player.Jump.performed -= ctx => jumpPressed = true;
        disablePlayerControl();
    }

    private void getComposents()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteTransform = GetComponentInChildren<SpriteRenderer>().transform;
    }

    public void enablePlayerControl()
    {
        inputActions.Player.Enable();
    }

    public void disablePlayerControl()
    {
        inputActions.Player.Disable();
    }
}
