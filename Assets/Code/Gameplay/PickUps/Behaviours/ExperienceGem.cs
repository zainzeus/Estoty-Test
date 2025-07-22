using UnityEngine;

namespace Code.Gameplay.PickUps.Behaviours
{
    public class ExperienceGem : MonoBehaviour
    {
        [SerializeField] private int xpAmount = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out HeroXP heroXP))
            {
                heroXP.AddXP(xpAmount);
                Destroy(gameObject);
            }
        }
    }
}