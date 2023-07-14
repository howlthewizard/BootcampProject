using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovingScript : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private float deceleration = 2f;
    Vector3 forward;
    Vector3 right;
    private Animator animator;

    float velocityZ=0f, velocityX =0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 1.5f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backPressed = Input.GetKey("s");

       
        

        if(forwardPressed && velocityZ < 1.5f)
        {
            velocityZ += Time.deltaTime * speed;
        }
        if (backPressed && velocityZ > -1.5f)
        {
            velocityZ -= Time.deltaTime * speed;
        }
        if (leftPressed && velocityX > -1.5f)
        {
            velocityX -= Time.deltaTime * speed;
        }
        if (rightPressed && velocityX < 1.5f)
        {
            velocityX += Time.deltaTime * speed;
        }
        if(!forwardPressed && velocityZ > 0f)
        {
            velocityZ -= Time.deltaTime * speed;
        }
        
        /*if (!forwardPressed && velocityZ < 0f)
        {
            velocityZ = 0f;
        }*/
        if (!backPressed && velocityZ < 0f)
        {
            velocityZ += Time.deltaTime * speed;
        }
        /*if(!backPressed && velocityZ >0)
        {
            velocityZ = 0f;
        }*/
        if (!leftPressed && velocityX < 0f )
        {
            velocityX += Time.deltaTime * speed;
        }
        if(!rightPressed && velocityX > 0f ) 
        {
            velocityX -= Time.deltaTime * speed;
        }
        if (!leftPressed && !rightPressed && velocityX !=0.0f &&(velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0f;
        }
        if(!forwardPressed && !backPressed && velocityZ != 0f && (velocityZ > -0.05f &&velocityZ < 0.05f))
        {
            velocityZ = 0f;
        }
      
        animator.SetFloat("VelocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);
    }

    private void FixedUpdate()
    {
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) 
            || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward += heading;
        transform.position += rightMovement;
        transform.position += upMovement;


    }
}  

