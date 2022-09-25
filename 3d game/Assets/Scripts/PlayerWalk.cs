using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    private Rigidbody body;
    private Animator anim;
    private CharacterController characterController;

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 10f;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }
}
