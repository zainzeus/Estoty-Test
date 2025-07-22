using UnityEngine;

namespace Code.Gameplay.Abilities.Behaviours
{
    public static class AbilitySystem
    {
        public static void Apply(AbilityType type, GameObject hero)
        {
            switch (type)
            {
                case AbilityType.HealthPotionBoost:
                    if (hero.GetComponent<HealthPotionBoostAbility>() == null)
                    {
                        hero.AddComponent<HealthPotionBoostAbility>().Apply(hero);
                        Debug.Log("Boost!");
                    }
                    break;

                case AbilityType.Bounce:
                    if (hero.GetComponent<BouncingProjectileAbility>() == null)
                    {
                        hero.AddComponent<BouncingProjectileAbility>().Apply(hero);
                        Debug.Log("Bounce!");
                    }
                    break;

                case AbilityType.Orbit:
                    if (hero.GetComponent<OrbitingProjectileAbility>() != null)
                    {
                        var ability = hero.GetComponent<OrbitingProjectileAbility>();
                        ability.Apply(hero);
                        Debug.Log("Orbit!");
                    }
                    break;

                case AbilityType.AgilityUp:
                    if (hero.GetComponent<AgilityUpAbility>() == null)
                    {
                        var ability = hero.AddComponent<AgilityUpAbility>();
                        ability.Apply(hero);
                        Debug.Log("Agility!");
                    }
                    break;

                case AbilityType.HealthUp:
                    if (hero.GetComponent<HealthUpAbility>() == null)
                    {
                        hero.AddComponent<HealthUpAbility>().Apply(hero);
                        Debug.Log("Health!");
                    }
                    break;

                case AbilityType.DamageUp:
                    if (hero.GetComponent<DamageUpAbility>() == null)
                    {
                        hero.AddComponent<DamageUpAbility>().Apply(hero);
                        Debug.Log("Damage!");
                    }
                    break;
            }
        }
    }
}
