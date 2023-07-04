using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public NavMeshAgent navMeshAgent;
    public bool isGrounded = true;
    public bool isJumping = false;
    public float fallMultiplier = 5000f;
    public float lowJumpMultiplier = 4000f;
    public float jumpForce = 50;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector3.up * jumpForce;
            isGrounded = false;
            isJumping = true;
            navMeshAgent.enabled = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && isJumping)
        {
            isGrounded = true;
            isJumping = false;
            navMeshAgent.enabled = true;
        }
    }

}
