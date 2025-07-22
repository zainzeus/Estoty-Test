using System;
using System.Collections.Generic;
using Code.Gameplay.Characters.Enemies.Behaviours;

namespace Code.Gameplay.Characters.Enemies.Services
{
	public class EnemyProvider : IEnemyProvider
	{
		private readonly List<Enemy> _activeEnemies = new();
		
		public event Action<Enemy> OnEnemyRegistered;
		public event Action<Enemy> OnEnemyUnregistered;

		public IEnumerable<Enemy> AllEnemies => _activeEnemies;

		public void RegisterEnemy(Enemy enemy)
		{
			if (enemy == null)
				throw new ArgumentNullException(nameof(enemy));

			if (!_activeEnemies.Contains(enemy))
			{
				_activeEnemies.Add(enemy);
				OnEnemyRegistered?.Invoke(enemy);
			}
		}
		
		public void UnregisterEnemy(Enemy enemy)
		{
			if (enemy == null)
				throw new ArgumentNullException(nameof(enemy));

			if (_activeEnemies.Contains(enemy))
			{
				_activeEnemies.Remove(enemy);
				OnEnemyUnregistered?.Invoke(enemy);
			}
		}
	}
}