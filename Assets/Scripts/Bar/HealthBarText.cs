using TMPro;
using UnityEngine;

namespace Bar
{
    public class HealthBarText : HealthBar
    {
        [SerializeField] protected TextMeshProUGUI _text;

        protected override void SetHealth(float currentHealth)
        {
            _text.text = $"{currentHealth}/{_entity.MaxHealth}";
        }
    }
}