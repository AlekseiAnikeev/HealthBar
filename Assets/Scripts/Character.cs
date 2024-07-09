using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    public float CurrentHealth { get; private set; }

    public event Action HasChanged;
    
    private float _minHealth = 0f;
    
    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Heal(5);
        }
    }

    public void Heal(float healingRate)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + healingRate, _minHealth, _maxHealth);
        
        HasChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, _minHealth, _maxHealth);
        
        HasChanged?.Invoke();
    }
}