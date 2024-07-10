using UnityEngine;

namespace Bar
{
    public abstract class HealthBar : MonoBehaviour
    {
        [SerializeField] protected Entity _entity;

        private void OnEnable()
        {
            _entity.HasChanged += SetHealth;
        }

        private void OnDisable()
        {
            _entity.HasChanged -= SetHealth;
        }

        protected abstract void SetHealth(float currentHealth);
    }
}