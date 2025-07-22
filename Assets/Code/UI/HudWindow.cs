using Code.Gameplay.Abilities.Behaviours;
using Code.Gameplay.Characters.Enemies.Services;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Infrastructure.UIManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
	public class HudWindow : WindowBase
	{
		[SerializeField] private Slider _healthBar;
		[SerializeField] private Text _killedEnemiesText;

		[SerializeField] private Slider _xpBar;
		[SerializeField] private Text _levelText;

		private IHeroProvider _heroProvider;
		private IEnemyDeathTracker _enemyDeathTracker;
		private HeroXP _heroXP;
		[SerializeField] private LevelUpWindow _levelUpWindow;


		public override bool IsUserCanClose => false;

		[Inject]
		private void Construct(IHeroProvider heroProvider, IEnemyDeathTracker enemyDeathTracker)
		{
			_enemyDeathTracker = enemyDeathTracker;
			_heroProvider = heroProvider;

			if (heroProvider.Hero != null)
            {
				_heroXP = heroProvider.Hero.GetComponent<HeroXP>();
				_heroXP.OnLevelUp += HandleLevelUp;
			}
		}

		protected override void OnUpdate()
		{
			UpdateHealthBar();
			UpdateKilledEnemiesText();
			UpdateXPBar();
			UpdateLevelText();
		}

		private void UpdateKilledEnemiesText()
		{
			_killedEnemiesText.text = _enemyDeathTracker.TotalKilledEnemies.ToString();
		}

		private void UpdateHealthBar()
		{
			if (_heroProvider.Hero != null)
				_healthBar.value = _heroProvider.Health.CurrentHealth / _heroProvider.Health.MaxHealth;
			else
				_healthBar.value = 0;
		}

        #region XP

        private void OnEnable()
		{
			if (_heroXP != null)
				_heroXP.OnXPChanged += UpdateXPBar;
		}

		private void OnDisable()
		{
			if (_heroXP != null)
				_heroXP.OnXPChanged -= UpdateXPBar;
		}

        private void OnDestroy()
        {
			if (_heroXP != null)
				_heroXP.OnLevelUp -= HandleLevelUp;
		}

        private void UpdateXPBar()
		{
			if (_heroXP != null)
				_xpBar.value = _heroXP.CurrentXP / 10f; 
		}

		private void UpdateLevelText()
		{
			if (_heroXP != null)
				_levelText.text = $"Lv. {_heroXP.Level}";
		}

		private void HandleLevelUp()
		{
			_levelUpWindow.ShowLevelUpChoices(_heroProvider.Hero.gameObject);
		}

		#endregion
	}
}