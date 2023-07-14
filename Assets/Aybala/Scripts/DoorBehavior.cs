using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool _isDoorOpen = false;
    private Vector3 _doorClosedPos;
    private Vector3 _doorOpenPos;
    private float _doorSpeed = 10f;

    private void Awake()
    {
        _doorClosedPos = transform.position;
        _doorOpenPos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
    }
    
    void Update()
    {
        if (_isDoorOpen)
        {
            OpenDoor();
        }
        else if (!_isDoorOpen)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (transform.position != _doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _doorOpenPos, _doorSpeed * Time.deltaTime);
        }
    }
    
    void CloseDoor()
    {
        if (transform.position != _doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _doorClosedPos, _doorSpeed * Time.deltaTime);
        }
    }
}
