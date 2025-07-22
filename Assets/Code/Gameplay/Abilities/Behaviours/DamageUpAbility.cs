using UnityEngine;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Gameplay.Abilities.Interfaces;

namespace Code.Gameplay.Abilities.Behaviours
{
    public class DamageUpAbility : MonoBehaviour, IAbility
    {
        [SerializeField] private float bonusDamage = 5f;

        public void Apply(GameObject target)
        {
            var stats = target.GetComponent<Stats>();
            if (stats == null) return;

            var modifier = new StatModifier(StatType.Damage, bonusDamage);
            stats.AddStatModifier(modifier);

            Debug.Log($" Damage Up applied: +{bonusDamage} damage");
        }
    }
}
