using UnityEngine;
using System;
using System.Collections.Generic;

namespace AI.Abilities
{
    public abstract class EffectStrategy : ScriptableObject
    {
        public abstract void StartEffect(AbilityData data, Action finished);
    }
}