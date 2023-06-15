using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingScript : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private Transform _model;
    [SerializeField] private Animator _animator;
    public bool isMoving = false;
    private Vector3 _input;
    public Vector3 lastMovePosition;
    Animator animator;
    public float acceleration = 0.1f;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        isMoving = false;
        //_animator.SetFloat("RunSpeed", 0f);
        GatherInput();
        Look();

       float velocityX = Vector3.Dot(_input.normalized,transform.right);
       float velocityZ = Vector3.Dot(_input.normalized, transform.forward);

        animator.SetFloat("VelocityX",velocityX, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityZ",velocityZ, 0.1f, Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
        _animator.SetFloat("RunSpeed", 0f);
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        Quaternion rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        _model.rotation = Quaternion.RotateTowards(_model.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + _input.ToIso() * _input.normalized.magnitude * _speed * Time.deltaTime);
        lastMovePosition = _rb.position;
        isMoving = true;
        _animator.SetFloat("RunSpeed",1f);
    }
}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}

