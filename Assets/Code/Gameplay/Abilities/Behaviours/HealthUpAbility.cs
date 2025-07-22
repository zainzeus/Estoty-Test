using UnityEngine;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.Abilities.Interfaces;

namespace Code.Gameplay.Abilities.Behaviours
{
    public class HealthUpAbility : MonoBehaviour, IAbility
    {
        [SerializeField] private float bonusHealth = 20f;

        public void Apply(GameObject target)
        {
            var stats = target.GetComponent<Stats>();
            var health = target.GetComponent<Health>();

            if (stats == null || health == null)
                return;

           
            var modifier = new StatModifier(StatType.MaxHealth, bonusHealth);
            stats.AddStatModifier(modifier);

            
            float max = stats.GetStat(StatType.MaxHealth);
            health.Setup(max, max); 
        }
    }
}
