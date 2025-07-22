using UnityEngine;

namespace Code.Gameplay.Abilities.Behaviours
{
    [CreateAssetMenu(fileName = "AbilityCard", menuName = Constants.GameName + "/ScriptableObjects/AbilityCard")]
    public class AbilityCardSO : ScriptableObject
    {
        public string Title;
        public string Description;
        public Sprite Icon;
        public AbilityType AbilityType;
        public bool CanOnlyBeGainedOnce;
    }

    public enum AbilityType
    {
        HealthPotionBoost,
        Bounce,
        Orbit,
        AgilityUp,
        HealthUp,
        DamageUp
    }
}
