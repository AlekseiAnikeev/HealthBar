using TMPro;
using UnityEngine;

namespace Bar
{
    public class HealthBarText : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _text;
        [SerializeField] protected Character _character;
    
        protected float _maxHealth;

        private void Start()
        {
            _maxHealth = _character.CurrentHealth;
            _text.text = $"{_maxHealth}/{_maxHealth}";
        }
        
        protected void OnEnable()
        {
            _character.HasChanged += SetHealth;
        }

        protected void OnDisable()
        {
            _character.HasChanged -= SetHealth;
        }

        protected virtual void SetHealth()
        {
            _text.text = $"{_character.CurrentHealth}/{_maxHealth}";
        }
    }
}
