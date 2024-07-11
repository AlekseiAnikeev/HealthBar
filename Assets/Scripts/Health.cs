using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    private float _currentHealth;
    private float _minHealth = 0f;

    public event Action<float> ValueChanged;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        ValueChanged?.Invoke(_currentHealth);
    }

    public void Heal(float healingRate)
    {
        if (healingRate >= 0)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + healingRate, _minHealth, _maxHealth);

            ValueChanged?.Invoke(_currentHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if(damage >= 0)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);

            ValueChanged?.Invoke(_currentHealth);
        }
    }
}