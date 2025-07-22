using UnityEngine;

namespace Code.Gameplay.Characters.Enemies.Configs
{
	[CreateAssetMenu(fileName = "DifficultyConfig",menuName = Constants.GameName + "/Configs/Difficulty")]
	public class DifficultyConfig : ScriptableObject
	{
		public float hpGrowthRate;
		public float damageGrowthRate;
	}
}