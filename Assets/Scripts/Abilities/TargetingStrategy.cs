using UnityEngine;
using System;
using System.Collections.Generic;

namespace AI.Abilities
{
    public abstract class TargetingStrategy : ScriptableObject
    {
        public abstract void StartTargeting(AbilityData data, Action finished);
    }
}
