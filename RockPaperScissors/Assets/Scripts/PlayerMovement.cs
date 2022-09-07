using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private float hSpeed = 0.0f;
    private float vSpeed = 0.0f;

    [Header("Collision")]
    [SerializeField] private LayerMask layerMask;
    private Rigidbody body;
    private BoxCollider boxCollider;
    [SerializeField] private bool isGrounded = false;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        hSpeed = speed * Input.GetAxis("Horizontal");
        CheckGrounded();
        if (isGrounded)
            print("idk");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        body.velocity = new Vector3(hSpeed, body.velocity.y, 0.0f);
    }

    private void Jump()
    {
        body.velocity = new Vector3(body.velocity.x, jumpHeight, 0.0f);
    }

    private void CheckGrounded()
    {
        Vector3 boxPosition = transform.position; // Box position
        Vector3 boxHalfSize = boxCollider.bounds.size * 0.5f; // Half size of the box
        Quaternion boxRotation = transform.rotation; // Box rotation
        Vector3 castDirection = -transform.up; // Cast direction
        RaycastHit hitResult; // Stores the result
        // Call BoxCast
        if (Physics.BoxCast(boxPosition, boxHalfSize, castDirection, out hitResult, boxRotation, 0.1f))
        {
            Debug.Log($"BoxCast hitted: {hitResult.collider.tag}, {isGrounded}");
            if (hitResult.collider.tag == "Ground")
                isGrounded = true;
            else
                isGrounded = false;
        }
        else
            isGrounded = false;
    }
}
