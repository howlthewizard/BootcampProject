using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpingForce;
    bool isJumping;

    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpingForce);
            isJumping = false;
        }
    }
}
