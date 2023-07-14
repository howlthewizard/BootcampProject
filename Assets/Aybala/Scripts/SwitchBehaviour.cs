using System;
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
    
    [SerializeField] private InventoryManager.AllItems _requiredItem;

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

    void MoveSwitchDown()
    {
        if (transform.position != _switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchDownPos, _switchSpeed * Time.deltaTime);
        }
    }
    
    void MoveSwitchUp()
    {
        if (transform.position != _switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchUpPos, _switchSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "Player")
        {
            _isPressingSwitch = !_isPressingSwitch;

            if (HasRequiredItem(_requiredItem))
            {
                if (_isDoorOpenSwitch && !_doorBehavior._isDoorOpen)
                {
                    _doorBehavior._isDoorOpen = !_doorBehavior._isDoorOpen;
                }
                else if (_isDoorCloseSwitch && _doorBehavior._isDoorOpen) 
                {
                    _doorBehavior._isDoorOpen = !_doorBehavior._isDoorOpen;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag== "Player")
        {
            StartCoroutine(SwitchUpDelay(_switchDelay));
        }
    }

    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _isPressingSwitch = false;
    }

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    
}
