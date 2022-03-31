using System;
using Model.Gameplay.Entity;
using UnityEngine;

namespace Model.Gameplay.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private bool _hitDestructables;
        [Header("Effect")]
        [SerializeField] private int _damage;
        [SerializeField] private float _pushForce;
        [SerializeField] private float _disorientationTime;
        [SerializeField] private DisorientationType _disorientationType;

        private Rigidbody _rigidbody;
        private Vector3 _direction;

        public event Action<Hitbox> OnHit;
        public event Action OnMiss;

        private Rigidbody Rigidbody => _rigidbody ??= GetComponent<Rigidbody>();
        private Vector3 Velocity => _direction * _speed;

        public void Init(Vector3 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            Rigidbody.position += Velocity * Time.fixedDeltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Hitbox target))
            {
                HandleHit(target);
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Hitbox target))
            {
                HandleHit(target);
            }
            else
            {
                OnMiss?.Invoke();
            }
            Destroy(gameObject);
        }

        private void HandleHit(Hitbox target)
        {
            if (target.Type != TargetType.Neutral || _hitDestructables)
            {
                target.TakeHit(_damage, _disorientationTime, _disorientationType, _direction, _pushForce);
            }
            OnHit?.Invoke(target);
        }
    }
}