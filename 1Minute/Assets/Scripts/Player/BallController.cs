using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;

    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    public float jumpForce = 10f;

    public Transform groundCheck;
    public float checkRadius = 0.4f;
    public LayerMask ground;

    private float currentHealth;
    public float maxHealth = 100f;

    public Transform bombPosition;

    public Animator animator;
    public GameObject bomb;

    private bool isGrounded;
    public bool ballBombUnlocked = false;

    Vector2 moveInput;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        Move();

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.J) && ballBombUnlocked)
        {
            Instantiate(bomb, bombPosition.position, bomb.transform.rotation);
        }

        SetAnimation();
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * moveInput.x, rb.velocity.y);
    }

    void SetAnimation()
    {
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }
}
