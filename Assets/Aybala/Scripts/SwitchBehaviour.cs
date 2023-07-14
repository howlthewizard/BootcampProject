using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] private DoorBehavior _doorBehavior;

    [SerializeField] private bool _isDoorOpenSwitch;
    [SerializeField] private bool _isDoorCloseSwitch;

    private float _switchSizeY;
    private Vector3 _switchUpPos;
    private Vector3 _switchDownPos;
    private float _switchSpeed = 1f;
    private float _switchDelay = 0.2f;
    private bool _isPressingSwitch = false;

    void Awake()
    {
        _switchSizeY = transform.localScale.y / 2;
        _switchUpPos = transform.position;
        _switchDownPos = new Vector3(transform.position.x, transform.position.y + _switchSizeY, transform.position.z);

    }

    void Update()
    {
        if (_isPressingSwitch)
        {
            MoveSwitchDown();
        }
        else if (!_isPressingSwitch)
        {
            MoveSwitchUp();
        }
    }
}
