using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bar
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _text;
    
        private float _maxHealth;

        public void SetMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            _slider.maxValue = maxHealth;
            _slider.value = maxHealth;
            _text.text = $"{maxHealth}/{maxHealth}";
        }

        public void SetHealth(float health)
        {
            _slider.value = health;
            _text.text = $"{health}/{_maxHealth}";
        }
    }
}