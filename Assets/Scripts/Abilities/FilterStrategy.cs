using UnityEngine;
using System;
using System.Collections.Generic;

namespace AI.Abilities
{
    public abstract class FilterStrategy : ScriptableObject
    {
        public abstract IEnumerable<GameObject> Filter(IEnumerable<GameObject> objectsToFilter);
    }
}
