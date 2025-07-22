using Code.Gameplay.Characters.Enemies.Behaviours;
using Code.Gameplay.Characters.Enemies.Configs;
using Code.Gameplay.Identification.Behaviours;
using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Infrastructure.ConfigsManagement;
using Code.Infrastructure.Identification;
using Code.Infrastructure.Instantiation;
using UnityEngine;

namespace Code.Gameplay.Characters.Enemies.Services
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IConfigsService _configsService;
        private readonly IInstantiateService _instantiateService;
        private readonly IIdentifierService _identifiers;
        private readonly DifficultyManager _difficultyManager;

        public EnemyFactory(
            IConfigsService configsService,
            IInstantiateService instantiateService,
            IIdentifierService identifiers,
             DifficultyManager difficultyManager)
        {
            _configsService = configsService;
            _instantiateService = instantiateService;
            _identifiers = identifiers;
            _difficultyManager = difficultyManager;
        }

        public Enemy CreateEnemy(EnemyId id, Vector3 at, Quaternion rotation)
        {
            EnemyConfig enemyConfig = _configsService.GetEnemyConfig(id);
            Enemy enemy = _instantiateService.InstantiatePrefabForComponent(enemyConfig.Prefab, at, rotation);

            enemy.GetComponent<Id>()
                .Setup(_identifiers.Next());

            float scaledHealth = enemyConfig.Health * _difficultyManager.HPMultiplier;
            float scaledDamage = enemyConfig.Damage * _difficultyManager.DamageMultiplier;

            enemy.GetComponent<Stats>()
                .SetBaseStat(StatType.MaxHealth, scaledHealth)
                .SetBaseStat(StatType.MovementSpeed, enemyConfig.MovementSpeed)
                .SetBaseStat(StatType.Damage, scaledDamage);

            enemy.GetComponent<Health>()
                .Setup(scaledHealth, scaledHealth);

            return enemy;
        }
    }
}