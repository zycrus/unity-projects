using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float hSpeed = 0.0f;
    [SerializeField] private float vSpeed = 0.0f;
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float maxJumpHeight = 10.0f;
    [SerializeField] private float minJumpHeight = 5f;
    [SerializeField] public float direction = 1f;
    [SerializeField] private bool isJumping = false;
    private Rigidbody2D body;

    [Header("Timers")]
    [SerializeField] private float elapsedTime = 0f;
    [SerializeField] private float jumpTime = 0.2f;

    [Header("Ground Detection")]
    public bool isGrounded = false;

    [Header("Attacks")]
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private Transform rockOffset;
    [SerializeField] private float rockOffsetDistance = 1f;
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private Transform paperOffset;
    [SerializeField] private float paperOffsetDistance = 0.5f;
    [SerializeField] private GameObject scissorsPrefab;
    [SerializeField] private Scissors scissorsScripts;
    [SerializeField] private Transform scissorsOffset;
    [SerializeField] private float scissorsOffsetDistance = 0.3f;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] public float recoverTimer = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        SpawnAttack();

        Move();

        body.velocity = new Vector2(hSpeed, body.velocity.y);
    }

    private void Move()
    {
        if (!isAttacking)
        {
<<<<<<< HEAD
            if (Input.GetAxis("Horizontal") > 0)
            {
                direction = 1;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                direction = -1;
            }
            rockOffset.localPosition = new Vector3(direction * rockOffsetDistance, 0, 0);
        }
        hSpeed = maxSpeed * Input.GetAxisRaw("Horizontal");

        Jump();
=======
            if (Input.GetAxis("Horizontal") != 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    direction = 1;
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    direction = -1;
                }
                rockOffset.localPosition = new Vector3(direction * rockOffsetDistance, 0, 0);
                paperOffset.localPosition = new Vector3(direction * paperOffsetDistance, 0, 0);
                scissorsOffset.localPosition = new Vector3(direction * scissorsOffsetDistance, 0, 0);

                hSpeed = maxSpeed * Input.GetAxisRaw("Horizontal");
            }

            Jump();
        }
        else if (isAttacking)
        {
            hSpeed = 0;
        }
>>>>>>> 6ab8bb0bcda0d7a600529e178ea6cac2df17528b
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             if (isGrounded)
            {
                isJumping = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            elapsedTime = 0;
        }

        if (isJumping)
        {
            elapsedTime += Time.deltaTime;
            body.velocity = new Vector2(body.velocity.x, Mathf.Lerp(minJumpHeight, maxJumpHeight, elapsedTime / jumpTime));
        }

        if (body.velocity.y > maxJumpHeight * 0.9)
        {
            isJumping = false;
        }
        //body.velocity = new Vector2(body.velocity.x, jumpHeight);
        vSpeed = body.velocity.y;
    }

    void SpawnAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Instantiate(rockPrefab, rockOffset);
        }
        if (Input.GetKeyDown(KeyCode.E) && !isAttacking)
        {
            Instantiate(scissorsPrefab, scissorsOffset);
            scissorsScripts = GetComponentInChildren<Scissors>();
            scissorsScripts.Meelee();
        }
        if (Input.GetMouseButton(1))
        {
            if (!isAttacking)
            {
                paperOffset.gameObject.SetActive(true);
                isAttacking = true;
            }
        }
        else
        {
            paperOffset.gameObject.SetActive(false);

            if (recoverTimer > 0)
            {
                isAttacking = true;
                recoverTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                recoverTimer = 0;
            }
        }
    }
}
