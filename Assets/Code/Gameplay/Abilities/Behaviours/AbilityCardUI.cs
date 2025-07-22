using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Abilities.Behaviours
{
    public class AbilityCardUI : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _title;
        private AbilityCardSO _card;
        private System.Action<AbilityCardSO> _onChosen;

        public void Setup(AbilityCardSO card, System.Action<AbilityCardSO> onChosen)
        {
            _card = card;
            _onChosen = onChosen;

            _icon.sprite = card.Icon;
            _title.text = card.Title;
        }

        public void OnClick()
        {
            _onChosen?.Invoke(_card);
        }
    }
}