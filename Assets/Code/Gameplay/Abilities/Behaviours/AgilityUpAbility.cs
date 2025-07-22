using UnityEngine;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Gameplay.Abilities.Interfaces;

namespace Code.Gameplay.Abilities.Behaviours
{
    public class AgilityUpAbility : MonoBehaviour, IAbility
    {
        [SerializeField] private float bonusAmount = 2.5f;

        public void Apply(GameObject target)
        {
            var stats = target.GetComponent<Stats>();
            if (stats != null)
            {
                var modifier = new StatModifier(StatType.RotationSpeed, bonusAmount);
                stats.AddStatModifier(modifier);
            }
        }
    }
}
