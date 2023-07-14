using AI.Inventories;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Abilities
{
    [CreateAssetMenu(fileName = "My Ability", menuName = "Abilities/Ability", order = 0)]
    public class Ability : ActionItem
    {
        [SerializeField] TargetingStrategy targetingStrategy;
        [SerializeField] FilterStrategy[] filterStrategies;
        [SerializeField] EffectStrategy[] effectStrategies;
        [SerializeField] float cooldownTime = 0;

        public override bool Use(GameObject user)
        {
            CoolDownStore cooldownStore = user.GetComponent<CoolDownStore>();
            if(cooldownStore.GetTimeRemaining(this) > 0)
            {
                return true;
            }

            AbilityData data = new AbilityData(user);

            targetingStrategy.StartTargeting(data, () => { TargetAquired(data);});
            return true;
        }

        private void TargetAquired(AbilityData data)
        {
            CoolDownStore cooldownStore = data.GetUser().GetComponent<CoolDownStore>();
            cooldownStore.StartCooldown(this, cooldownTime);

            foreach (var filterStrategy in filterStrategies)
            {
                data.SetTargets(filterStrategy.Filter(data.GetTargets()));
            }            

            foreach(var effect in effectStrategies)
            {
                effect.StartEffect(data, EffectFinished);
            }
        }

        private void EffectFinished()
        {

        }
    }
}
