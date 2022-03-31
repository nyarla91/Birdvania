using NyarlaEssentials;
using UnityEngine;

namespace Model.Gameplay.Entity
{
    public class Hitbox : Transformer
    {
        [SerializeField] private HealthStorage _healthStorage;
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private Disoriented _disoriented;
        [SerializeField] private Movable _movable;
        [Space]
        [SerializeField] private TargetType _type;
        [SerializeField] private float _hitImmunityDuration;
        [Space]
        [SerializeField] private HarpoonPullMode _harpoonPullMode;
        

        public TargetType Type => _type;

        public HarpoonPullMode HarpoonPullMode => _harpoonPullMode;
        public StateMachine StateMachine => _stateMachine;
        public Movable Movable => _movable;

        public void TakeHit(int damage, float disorientationDuration, DisorientationType disorientationType,
            Vector3 directionTo, float pushForce)
        {
            _healthStorage?.TakeDamage(damage);
            _movable?.SetForce(directionTo * pushForce, true);
            
            if (_hitImmunityDuration <= 0 || _disoriented == null)
                return;

            switch (disorientationType)
            {
                case DisorientationType.Stun:
                    _disoriented.Stun(disorientationDuration);
                    break;
                case DisorientationType.Stagger:
                    _disoriented.Stagger(disorientationDuration);
                    break;
                case DisorientationType.Freeze:
                    _disoriented.Stun(disorientationDuration);
                    break;
            }
        }
    }

    public enum TargetType
    {
        Player,
        Enemy,
        Neutral
    }

    public enum HarpoonPullMode
    {
        None,
        PullPlayer,
        PullTarget,
    }
}