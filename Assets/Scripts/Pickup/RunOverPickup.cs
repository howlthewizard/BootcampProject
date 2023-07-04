using AI.Inventories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Control
{
    [RequireComponent(typeof(Pickup))]
    public class RunOverPickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if(other.gameObject == player)
            {
                GetComponent<Pickup>().PickupItem();
            }
        }
    }

}
