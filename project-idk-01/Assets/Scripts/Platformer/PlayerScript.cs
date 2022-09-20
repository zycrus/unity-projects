using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float xSpeed;
    [SerializeField] private int direction = 1;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private bool isGrounded = false;
    private Rigidbody2D body;

    [Header("Shoot")]
    [SerializeField] private bool isCharging = false;
    [SerializeField] private bool isShooting = false;
    //[SerializeField] private float chargeTime = 1f;
    [SerializeField] private float timer;
    [SerializeField] private Transform firePoint;
    public LineRenderer lineRenderer;

    [Header("Animation")]
    private Animator animator;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W) && (!isCharging || !isShooting))
            {
                body.velocity = new Vector2(xSpeed, jumpHeight);
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (direction > 0)
            {
                transform.Rotate(0f, 180f, 0f);
                direction = -1;
            }
            if (isGrounded) animator.SetBool("Walk", true);
            else animator.SetBool("Walk", false);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (direction < 0)
            {
                transform.Rotate(0f, 180f, 0f);
                direction = 1;
            }
            if (isGrounded) animator.SetBool("Walk", true);
            else animator.SetBool("Walk", false);
        }
        else animator.SetBool("Walk", false);

        if (Input.GetKeyDown(KeyCode.F))
        {
            isCharging = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            isCharging = false;
            if(!isShooting) Shoot();
        }
        animator.SetBool("Charge", isCharging);
    }

    private void FixedUpdate()
    {
        if (!isCharging || !isShooting) xSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed;
        else xSpeed = 0f;
        body.velocity = new Vector2(xSpeed, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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

    public void Shoot()
    {
        isShooting = true;
        animator.SetTrigger("Shoot");
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, 5f);
        body.AddForce(body.transform.up * 3, ForceMode2D.Impulse);
        body.AddForce(firePoint.right * -2, ForceMode2D.Impulse);  // FIX THIS PART NOT WORKING
        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            if (hitInfo.transform.name == "Dummy")
            {
                Animator enemyAnim = hitInfo.transform.GetComponent<Animator>();
                Rigidbody2D enemyBody = hitInfo.transform.GetComponent<Rigidbody2D>();
                enemyAnim.SetTrigger("Damage");
                enemyBody.AddForce(firePoint.right * 2, ForceMode2D.Impulse);
                enemyBody.AddForce(enemyBody.transform.up * 5, ForceMode2D.Impulse);
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point + new Vector2(0.05f, 0f));
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 5f);
        }
        lineRenderer.enabled = true;
    }

    public void DisableLineRenderer()
    {
        isShooting = false;
        lineRenderer.enabled = false;
    }
}
