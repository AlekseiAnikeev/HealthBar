using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    private float _currentHealth;
    private float _minHealth = 0f;

    public event Action<float> HasChanged;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        HasChanged?.Invoke(_currentHealth);
    }

    public void Heal(float healingRate)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + healingRate, _minHealth, _maxHealth);

        HasChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);

        HasChanged?.Invoke(_currentHealth);
    }
}