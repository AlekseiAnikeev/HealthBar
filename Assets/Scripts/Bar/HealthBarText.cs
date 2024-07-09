using TMPro;
using UnityEngine;

namespace Bar
{
    public class HealthBarText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
    
        private float _maxHealth;

        public void SetMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            _text.text = $"{maxHealth}/{maxHealth}";
        }

        public void SetHealth(float health)
        {
            _text.text = $"{health}/{_maxHealth}";
        }
    }
}
