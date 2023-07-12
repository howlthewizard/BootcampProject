using AI.Inventories;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Abilities
{
    [CreateAssetMenu(fileName = "My Ability", menuName = "Abilities/Ability", order = 0)]
    public class Ability : ActionItem
    {
        [SerializeField] TargetingStrategy targetingStrategy;
        [SerializeField] FilterStrategy[] filterStrategies;
        [SerializeField] EffectStrategy[] effectStrategies;

        public override bool Use(GameObject user)
        {
            AbilityData data = new AbilityData(user);

            targetingStrategy.StartTargeting(data, () => { TargetAquired(data);});
            return false;
        }

        private void TargetAquired(AbilityData data)
        {
            foreach(var filterStrategy in filterStrategies)
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
