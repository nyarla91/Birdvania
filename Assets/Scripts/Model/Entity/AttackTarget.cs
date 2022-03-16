using NyarlaEssentials;
using UnityEngine;

namespace Model.Entity
{
    public class AttackTarget : Transformer
    {
        [SerializeField] private TargetType _type;
        [SerializeField] private float _hitImmunityDuration;
        
        private Health _health;
        private Stunned _stunned;
        private Movable _movable;

        public TargetType Type => _type;

        public void TakeHit(int damage, float stunDuration, Vector3 push)
        {
            _health?.TakeDamage(damage);
            _stunned?.Stun(stunDuration);
            _movable?.SetForce(push, true);
        }
        
        private void Awake()
        {
            _health = GetComponent<Health>();
            _stunned = GetComponent<Stunned>();
            _movable = GetComponent<Movable>();
        }

        public enum TargetType
        {
            Player,
            Enemy,
            Neutral
        }
    }
}