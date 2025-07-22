using Code.Gameplay.Abilities.Interfaces;
using Code.Gameplay.Combat.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Abilities.Behaviours
{
    public class BouncingProjectileAbility : MonoBehaviour, IAbility
    {
        public void Apply(GameObject target)
        {
            var shooter = target.GetComponentInChildren<ShootProjectiles>();
            if (shooter != null)
            {
                shooter.EnableBouncing();
            }
        }
    }
}
