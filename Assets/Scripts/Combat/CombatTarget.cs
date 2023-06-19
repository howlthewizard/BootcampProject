using UnityEngine;
using AI.Combat;
using AI.Controller;
using Attributes;

namespace AI.Combat
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour, IRaycastable
    {
        public CursorType GetCursorType()
        {
            return CursorType.Combat;
        }

        public bool HandleRaycast(PlayerCursorController callingController)
        {
            if(!enabled) return false;
            if (!callingController.GetComponent<Fighter>().CanAttack(gameObject))
            {
                return false; //Means we cannot handle attack.
            }
            if (Input.GetMouseButton(0))
            {
                callingController.GetComponent<Fighter>().Attack(gameObject); // for this particular target.
            }
            return true;
        }
    }
}
