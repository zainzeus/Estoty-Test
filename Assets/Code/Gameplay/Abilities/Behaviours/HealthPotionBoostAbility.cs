using Code.Gameplay.Abilities.Interfaces;
using Code.Gameplay.Lifetime.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Abilities.Behaviours
{
    public class HealthPotionBoostAbility : MonoBehaviour, IAbility
    {
        public void Apply(GameObject target)
        {
            var health = target.GetComponent<Health>();
            if (health != null)
                health.SetHealingMultiplier(2f); 
        }
    }
}