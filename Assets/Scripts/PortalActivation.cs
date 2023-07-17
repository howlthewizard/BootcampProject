using Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivation : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private BoxCollider collider;
    private Health bossHealth;

    private void Awake()
    {
        bossHealth = boss.GetComponent<Health>();
    }
    private void Update()
    {
        if(bossHealth.IsDead())
        {
            collider.isTrigger = true;
        }
    }

}
