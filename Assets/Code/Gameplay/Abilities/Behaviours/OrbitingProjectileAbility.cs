using Code.Gameplay.Abilities.Interfaces;
using Code.Gameplay.Projectiles.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Abilities.Behaviours
{
    public class OrbitingProjectileAbility : MonoBehaviour, IAbility
    {
        [SerializeField] private GameObject orbitingProjectileSystemPrefab;

        public void Apply(GameObject target)
        {
            if (target.GetComponentInChildren<OrbitingProjectileSystem>() == null)
            {
                Instantiate(orbitingProjectileSystemPrefab, target.transform);
            }
        }
    }
}
