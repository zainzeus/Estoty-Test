using UnityEngine;

namespace Code.Gameplay.Projectiles.Behaviours
{
	public class Projectile : MonoBehaviour
	{

		public bool CanBounce() => _canBounce;
		public bool HasBounced() => _hasBounced;

		public void MarkBounced()
		{
			_hasBounced = true;
		}

		private bool _canBounce;
		private bool _hasBounced = false;

		public void SetCanBounce(bool value)
		{
			_canBounce = value;
		}
	}
}