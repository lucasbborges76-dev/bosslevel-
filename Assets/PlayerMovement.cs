using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    public SpriteRenderer sr;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimento lateral
        float moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("movementoX", moveInput);
        bool move = (moveInput == 0) ? false: true;
        animator.SetBool("movendo", move );

        if(move && moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(move && moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Verifica se está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
