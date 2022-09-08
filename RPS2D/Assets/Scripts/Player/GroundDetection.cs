using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [Header("Ground Detection")]
    [SerializeField] private PlayerControls playerControls;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerControls.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerControls.isGrounded = false;
    }
}
