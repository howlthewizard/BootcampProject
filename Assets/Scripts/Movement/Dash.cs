using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashForce = 10f; // Dash hýzý
    private bool isDashing = false;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            Dashing();
            rb.velocity = Vector3.zero;
        }
        /*else if(playerMovement.isMoving)
        {
           rb.velocity = Vector3.zero;
        }*/
    }

    private void Dashing()
    {
        rb.AddForce(transform.forward * dashForce,ForceMode.Impulse);
        isDashing = false;
    }

}
