using UnityEngine;
using AI.Controller;
using System.Collections;
using System;
using System.Collections.Generic;

namespace AI.Abilities.Targeting
{
    [CreateAssetMenu(fileName = "Demo Targeting", menuName = "Abilities/Targeting/Demo", order = 0)]
    public class DemoTargeting : TargetingStrategy
    {
        public override void StartTargeting(AbilityData data, Action finished)
        {
            Debug.Log("Demo targeting started");
            finished();
        }
    }
}
