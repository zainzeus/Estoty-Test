using UnityEngine;
using Zenject;


namespace Code.Gameplay.Characters.Enemies.Configs
{
    public class DifficultyManager : ITickable
    {
        private readonly DifficultyConfig _config;
        private float _elapsedTime;

        public float HPMultiplier => 1 + _config.hpGrowthRate * _elapsedTime;
        public float DamageMultiplier => 1 + _config.damageGrowthRate * _elapsedTime;

        public DifficultyManager(DifficultyConfig config)
        {
            _config = config;
        }

        public void Tick() => _elapsedTime += Time.deltaTime;
    }
}