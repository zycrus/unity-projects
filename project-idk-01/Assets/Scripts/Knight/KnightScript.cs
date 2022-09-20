using UnityEngine;

public class KnightScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float xSpeed;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private int direction = 1;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private bool isGrounded = false;
    private Rigidbody2D body;

    [Header("Animation")]
    private Animator animator;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        xSpeed = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (xSpeed < 0)
        {
            if (direction > 0)
            {
                direction = -1;
                transform.Rotate(0f, 180f, 0f);
            }
            else animator.SetBool("Run", true);
        }
        else if (xSpeed > 0)
        {
            if (direction < 0)
            {
                direction = 1;
                transform.Rotate(0f, 180f, 0f);
            }
            else animator.SetBool("Run", true);
        }
        else animator.SetBool("Run", false);

        if (isGrounded)
        {
            animator.SetBool("Fall", false);

            if (Input.GetKeyDown(KeyCode.W))
            {
                body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                animator.SetBool("Jump", true);
            }
        }
        else if (body.velocity.y < 0 )
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack1();
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(xSpeed, body.velocity.y);
    }

    private void Attack1()
    {
        animator.SetTrigger("Attack1");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Fall", false);
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
