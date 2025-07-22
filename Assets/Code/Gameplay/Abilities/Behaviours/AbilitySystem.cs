using UnityEngine;

namespace Code.Gameplay.Abilities.Behaviours
{
    public static class AbilitySystem
    {
        public static void Apply(AbilityType type)
        {
            switch (type)
            {
                case AbilityType.HealthPotionBoost:
                    Debug.Log("Applied Health Potion Boost");
                    
                    break;

                case AbilityType.Bounce:
                    Debug.Log("Applied Bouncing Projectiles");
                   
                    break;

                case AbilityType.Orbit:
                    Debug.Log("Applied Orbiting Projectiles");
                    
                    break;

                case AbilityType.AgilityUp:
                    Debug.Log("Applied Agility Up");
                   
                    break;

                case AbilityType.HealthUp:
                    Debug.Log("Applied Health Up");
                   
                    break;

                case AbilityType.DamageUp:
                    Debug.Log("Applied Damage Up");
                    
                    break;
            }
        }
    }
}
