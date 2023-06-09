using UnityEngine;
using UnityEngine.Events;

namespace AI.Combat
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] UnityEvent onHit;
        public void OnHit()
        {
            onHit.Invoke();
        }
    }
}