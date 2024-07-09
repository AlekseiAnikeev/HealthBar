using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Bar
{
    public class HealthBarSmooth : HealthBarText
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _delta = 10f;
    
        private Coroutine _activeCoroutine;

        private void Start()
        {
            _maxHealth = _character.CurrentHealth;;
            _slider.maxValue = _maxHealth;
            _slider.value = _maxHealth;
            _text.text = $"{_maxHealth}/{_maxHealth}";
        }

        protected override void SetHealth()
        {
            base.SetHealth();
            
            if (_activeCoroutine != null)
                StopCoroutine(_activeCoroutine);

            _activeCoroutine = StartCoroutine(DrawFillingOfSlider());
        }

        private IEnumerator DrawFillingOfSlider()
        {
            float accuracy = 0.00001f;

            while (Math.Abs(_slider.value - _character.CurrentHealth) > accuracy)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, _character.CurrentHealth, _delta * Time.deltaTime);
                
                yield return null;
            }
        }
    }
}
