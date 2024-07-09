using UnityEngine;
using UnityEngine.UI;

namespace Bar
{
    public class HealthBar : HealthBarText
    {
        [SerializeField] private Slider _slider;

        private void Start()
        {
            _maxHealth = _character.CurrentHealth;
            _slider.maxValue = _maxHealth;
            _slider.value = _maxHealth;
            _text.text = $"{_maxHealth}/{_maxHealth}";
        }

        protected override void SetHealth()
        {
            _slider.value = _character.CurrentHealth;
            
            base.SetHealth();
        }
    }
}