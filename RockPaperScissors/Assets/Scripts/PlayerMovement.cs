using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody body;

    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private bool isGrounded = false;

    public bool isAttacking = false;

    [SerializeField] private GameObject offset;
    Transform offsetTransform;
    [SerializeField] private GameObject[] attackObject;
    [SerializeField] private Animator[] attackAnim;
    private int direction = 1;

    public AttackSelect attackSelect;
    private int selected;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        offsetTransform = offset.transform;
        attackAnim[0] = attackObject[0].GetComponent<Animator>();
        attackAnim[1] = attackObject[1].GetComponent<Animator>();
        attackAnim[2] = attackObject[2].GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        selected = attackSelect.selectPos;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = -1;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = 1;
        }
        
        body.velocity = new Vector3(speed * Input.GetAxis("Horizontal"), body.velocity.y, 0);
        offsetTransform.position = new Vector3(transform.position.x + (attackObject[selected].transform.localScale.x) * direction, transform.position.y, transform.position.z);
        attackObject[selected].transform.position = offsetTransform.position;

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                isGrounded = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
            isAttacking = false;
        }
    }

    private void Attack()
    {
        attackObject[selected].SetActive(true);
        attackAnim[selected].SetTrigger("Attack");
    }

    private void Jump()
    {
        body.velocity = new Vector3(body.velocity.x * 0.6f, jumpHeight, body.velocity.x);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
