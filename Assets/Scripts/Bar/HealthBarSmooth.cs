using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bar
{
    public class HealthBarSmooth : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _delta = 10f;
    
        private float _maxHealth;
        private float _target;

        private void Update()
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _target, _delta * Time.deltaTime);
        }

        public void SetMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            _slider.maxValue = maxHealth;
            _slider.value = maxHealth;
            _target = maxHealth;
            _text.text = $"{maxHealth}/{maxHealth}";
        }

        public void SetHealth(float health)
        {
            _target = health;
            _text.text = $"{health}/{_maxHealth}";
        }
    }
}
