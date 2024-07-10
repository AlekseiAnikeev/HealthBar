using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bar
{
    public class HealthBarSmooth : HealthBar
    {
        [SerializeField] private Slider _slider;
        [SerializeField] protected TextMeshProUGUI _text;
        [SerializeField] private float _delta = 0.010f;

        private Coroutine _activeCoroutine;
        private float barValue;

        private void Start()
        {
            _slider.minValue = 0;
            _slider.maxValue = 1;
        }

        protected override void SetHealth(float currentHealth)
        {
            float currentValue = currentHealth / _entity.MaxHealth;

            _text.text = $"{currentHealth}/{_entity.MaxHealth}";

            if (_activeCoroutine != null)
                StopCoroutine(_activeCoroutine);

            _activeCoroutine = StartCoroutine(DrawFillingOfSlider(currentValue));
        }

        private IEnumerator DrawFillingOfSlider(float currentHealth)
        {
            float accuracy = 0.00001f;

            while (Math.Abs(_slider.value - currentHealth) > accuracy)
            {
                _slider.value = Mathf.Lerp(_slider.value, currentHealth, _delta);

                yield return null;
            }
        }
    }
}