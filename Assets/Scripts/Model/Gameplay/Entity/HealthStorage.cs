using System;
using Model.Gameplay.UI;
using NyarlaEssentials;
using Presenter.Gameplay.Entity.UI;
using UnityEngine;
using Zenject;

namespace Model.Gameplay.Entity
{
    public class HealthStorage : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [Header("Healthbar")]
        [SerializeField] private GameObject _healthbarPrefab;
        [SerializeField] private HealthShowMode _showMode;
        [SerializeField] private float _healthbarWidth;
        [SerializeField] private Vector2 _healthbarOffset;
        
        private int _health;

        public event Action<int, int> OnHealthChanged;

        public int MaxHealth
        {
            get => _maxHealth;
            private set => _maxHealth = value;
        }

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                OnHealthChanged?.Invoke(_health, _maxHealth);
            }
        }

        public HealthShowMode ShowMode => _showMode;

        [Inject]
        private void Construct(MainCanvas mainCanvas, CameraProperties cameraProperties)
        {
            HealthbarPresenter healthbar =
                Instantiate(_healthbarPrefab, Vector3.zero, Quaternion.identity, mainCanvas.transform)
                    .GetComponent<HealthbarPresenter>();
            
            healthbar.Init(this, _healthbarWidth, _healthbarOffset, cameraProperties);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        private void Awake()
        {
            Health = MaxHealth;
        }
    }

    public enum HealthShowMode
    {
        Never,
        WhenDamaged,
        Always,
    }
}