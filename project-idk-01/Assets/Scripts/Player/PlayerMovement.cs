using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 0.1f;
    private Vector3 mousePosition;
    private Vector3 position = new Vector3(0f, 0f, 0f);
    private Vector3 posWhileCollision;
    private Vector3 direction;
    private bool isColliding = false;
    private float posDiff_x;
    private float posDiff_y;
    private float direction_x, direction_y;
    private float angle;

    private Rigidbody body;



    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get Mouse Postion
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Get Angle From Player Towards the Mouse Position
        direction_x = mousePosition.x - transform.position.x;
        direction_y = mousePosition.y - transform.position.y;
        angle = Mathf.Atan2(direction_x, direction_y) * Mathf.Rad2Deg;
        direction = new Vector3(0, 0, -angle);
        

        // Reduce speed when colliding
        if (Mathf.Abs(direction_x) < 0.9f)
        { posDiff_x = 0; }
        else
        { posDiff_x = Mathf.Sign(direction_x); }
        if (Mathf.Abs(mousePosition.y - transform.position.y) < 0.9f)
        { posDiff_y = 0; }
        else
        { posDiff_y = Mathf.Sign(direction_y); }
        posWhileCollision = new Vector3(posDiff_x, posDiff_y, 0);

        // Move Player Towards Mouse
        if (!isColliding)
        {
            position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
        }
        else
        {
            position = Vector3.Lerp(transform.position, transform.position + posWhileCollision / 3, moveSpeed);
        }
    }

    private void FixedUpdate()
    {
        body.MovePosition(position);
        body.MoveRotation(Quaternion.Euler(direction));
    }

    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }
}
