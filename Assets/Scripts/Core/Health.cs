using System;
using UnityEngine;
using UnityEngine.Events;
using AI.Core;
using AI.Saving;
using AI.Stats;
using AI.Utils;

namespace Attributes
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float regenerationPercentage = 70;
        [SerializeField] TakeDamageEvent takeDamage;
        [SerializeField] private PlayerHealthBar healthBar; 
        public UnityEvent onDie;

        [System.Serializable]
        public class TakeDamageEvent : UnityEvent<float>
        {
        }

        LazyValue<float> _health;

        bool wasDeadLastFrame = false;

        private void Awake()
        {
            _health = new LazyValue<float>(GetInitialHealth);
        }

        private float GetInitialHealth()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        private void Start()
        {
            _health.ForceInit();
        }

        public bool IsDead()
        {
            return _health.value <= 0;
        }

        public void TakeDamage(GameObject instigator, float damage)
        {
            _health.value = Mathf.Max(_health.value - damage, 0);
            healthBar.SetHealth(_health.value);

            if (IsDead())
            {
                onDie.Invoke();
            }
            else
            {
                takeDamage.Invoke(damage);
            }
            UpdateState();
        }

        public void Heal(float healthToRestore)
        {
            _health.value = Mathf.Min(_health.value + healthToRestore, GetMaxHealthPoints());
            healthBar.SetHealth(_health.value);
            UpdateState();
        }

        public float GetHealthPoints()
        {
            return _health.value;
        }

        public float GetMaxHealthPoints()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        public float GetPercentage()
        {
            return 100 * GetFraction();
        }

        public float GetFraction()
        {
            return _health.value / GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        private void UpdateState()
        {
            Animator animator = GetComponent<Animator>();
            if (!wasDeadLastFrame && IsDead())
            {
                animator.SetTrigger("die");
                GetComponent<ActionScheduler>().CancelCurrentAction();
            }

            if (wasDeadLastFrame && !IsDead())
            {
                animator.Rebind();
            }

            wasDeadLastFrame = IsDead();
        }

        private void RegenerateHealth()
        {
            float regenHealthPoints = GetComponent<BaseStats>().GetStat(Stat.Health) * (regenerationPercentage / 100);
            _health.value = Mathf.Max(_health.value, regenHealthPoints);
        }

        public object CaptureState()
        {
            return _health.value;
        }

        public void RestoreState(object state)
        {
            _health.value = (float)state;

            UpdateState();
        }
    }
}