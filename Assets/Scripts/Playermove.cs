using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Playermove : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject cameraGb;
    [SerializeField] private float jumppower = 5;
     private float inputHorizontal;
     private float inputVertical;
    [SerializeField] Rigidbody rb;
    [SerializeField]private float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            rb.velocity = Vector3.up * jumppower;
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attack");
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isJumping = true;
        }
    }
    void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}
