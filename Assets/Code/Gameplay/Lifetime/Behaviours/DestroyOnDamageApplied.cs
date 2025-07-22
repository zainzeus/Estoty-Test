using Code.Gameplay.Projectiles.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
    [RequireComponent(typeof(IDamageApplier))]
    public class DestroyOnDamageApplied : MonoBehaviour
    {
        [SerializeField] private float _delay;

        private IDamageApplier _damageApplier;

        private void Awake()
        {
            _damageApplier = GetComponent<IDamageApplier>();
        }

        private void OnEnable()
        {
            _damageApplier.OnDamageApplied += HandleDamageApplied;
        }

        private void OnDisable()
        {
            _damageApplier.OnDamageApplied -= HandleDamageApplied;
        }

        private void HandleDamageApplied(Health _)
        {
            if (TryGetComponent(out Projectile projectile))
            {
                if (projectile.CanBounce() && !projectile.HasBounced())
                {
                    return;
                }
            }

            Destroy(gameObject, _delay);
        }
    }
}