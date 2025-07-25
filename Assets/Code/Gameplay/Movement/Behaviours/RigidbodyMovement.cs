using Code.Gameplay.Input.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Movement.Behaviours
{
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(IMovementDirectionProvider))]
	[RequireComponent(typeof(Stats))]
	public class RigidbodyMovement : MonoBehaviour, IMovement
	{
		private Rigidbody2D _rigidbody;
		private IMovementDirectionProvider _movementDirectionProvider;
		private Stats _stats;
		private bool isBouncing;
		public Vector2 Velocity { get; private set; }

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_movementDirectionProvider = GetComponent<IMovementDirectionProvider>();
			_stats = GetComponent<Stats>();
		}

		private void FixedUpdate()
		{

			if (isBouncing) return;
			CalculateVelocity();
			_rigidbody.velocity = Velocity;
		}

		private void CalculateVelocity()
		{
			Vector2 direction = _movementDirectionProvider.GetDirection();
			float speed = _stats.GetStat(StatType.MovementSpeed);
			Velocity = direction * speed;
		}

		public void ChangeDirection(Vector2 dir)
        {
			_movementDirectionProvider.SetDirection(dir);
			isBouncing = true;

			float speed = _stats.GetStat(StatType.MovementSpeed);
			Velocity = dir.normalized * speed;
			_rigidbody.velocity = Velocity;

			Debug.Log("Bounce direction set to: " + dir);
		}
	}
}