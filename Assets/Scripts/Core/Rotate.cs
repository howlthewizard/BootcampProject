using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speedFraction = 50f;
    private void Update()
    {
        if(gameObject.tag == "windMill")
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * speedFraction));
        }
        if(gameObject.tag == "waterMill")
        {
            transform.Rotate(new Vector3(Time.deltaTime * speedFraction, 0, 0));
        }
    }


}
