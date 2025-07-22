using UnityEngine;
using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.Characters.Enemies.Services;
using Code.Gameplay.Movement.Behaviours;
using Zenject;
using Code.Gameplay.Vision.Behaviours;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Gameplay.UnitStats;

namespace Code.Gameplay.Projectiles.Behaviours
{
    [RequireComponent(typeof(IDamageApplier))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Stats))]
    public class BounceOnDamageApplied : MonoBehaviour
    {
        [SerializeField] private float _delay = 2f;

        private IDamageApplier _damageApplier;
        private Rigidbody2D _rigidbody;
        private Stats _stats;
        private SettableMovementDirection _movementDirection;
        private RigidbodyMovement RM;

        private void Awake()
        {
            _damageApplier = GetComponent<IDamageApplier>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _stats = GetComponent<Stats>();
            _movementDirection = GetComponent<SettableMovementDirection>();
            RM = GetComponent<RigidbodyMovement>();

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
            _damageApplier.OnDamageApplied -= HandleDamageApplied;

            RM.ChangeDirection(GetRandomDirectionDifferentFrom(_movementDirection.GetDirection()));
            Destroy(gameObject, _delay);
        }

        private Vector2 GetRandomDirectionDifferentFrom(Vector2 current)
        {
            Vector2 newDir;
            int safety = 100;

            do
            {
                newDir = Random.insideUnitCircle.normalized;
                safety--;
            } while (Vector2.Dot(current, newDir) > 0.95f && safety > 0);

            return newDir;
        }
    }
}
