using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bar
{
    public class SliderHealthBar : HealthBar
    {
        [SerializeField] private Slider _slider;
        [SerializeField] protected TextMeshProUGUI _text;

        private void Start()
        {
            _slider.minValue = 0;
            _slider.maxValue = 1;
        }

        protected override void SetHealth(float currentHealth)
        {
            _slider.value = currentHealth / _entity.MaxHealth;
            _text.text = $"{currentHealth}/{_entity.MaxHealth}";
        }
    }
}