using Bar;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private HealthBarText _healthBarText;
    [SerializeField] private HealthBarSmooth _healthBarSmooth;
    
    private float _currentHealth;
    private float _minHealth = 0f;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
        _healthBarText.SetMaxHealth(_maxHealth);
        _healthBarSmooth.SetMaxHealth(_maxHealth);
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
        _currentHealth = Mathf.Clamp(_currentHealth + healingRate, _minHealth, _maxHealth);
        
        _healthBar.SetHealth(_currentHealth);
        _healthBarText.SetHealth(_currentHealth);
        _healthBarSmooth.SetHealth(_currentHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);
        
        _healthBar.SetHealth(_currentHealth);
        _healthBarText.SetHealth(_currentHealth);
        _healthBarSmooth.SetHealth(_currentHealth);
    }
}
