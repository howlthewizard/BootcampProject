using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Utils
{
    public interface IPredicateEvaluator
    {
        bool? Evaluate(string predicate, string[] parameters);
    }
}