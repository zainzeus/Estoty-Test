using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Code.Infrastructure.UIManagement;


namespace Code.Gameplay.Abilities.Behaviours
{
    public class LevelUpWindow : WindowBase
    {
        [SerializeField] private List<AbilityCardSO> _allCards;
        [SerializeField] private List<AbilityCardUI> _cardUIs;

        private HashSet<AbilityType> _alreadyGained = new();
        private GameObject _hero;
        public override bool IsUserCanClose => false;

        public void ShowLevelUpChoices(GameObject hero)
        {
            _hero = hero;
            gameObject.SetActive(true);

            var availableCards = _allCards
                .Where(c => !_alreadyGained.Contains(c.AbilityType) || !c.CanOnlyBeGainedOnce)
                .OrderBy(_ => Random.value)
                .Take(3)
                .ToList();

            for (int i = 0; i < _cardUIs.Count; i++)
            {
                _cardUIs[i].Setup(availableCards[i], OnCardChosen);
            }
        }

        private void OnCardChosen(AbilityCardSO chosenCard)
        {
            if (chosenCard.CanOnlyBeGainedOnce)
                _alreadyGained.Add(chosenCard.AbilityType);

            AbilitySystem.Apply(chosenCard.AbilityType, _hero);
            gameObject.SetActive(false);
        }
    }
}