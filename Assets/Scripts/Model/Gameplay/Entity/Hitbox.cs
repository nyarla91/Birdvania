﻿using NyarlaEssentials;
using UnityEngine;

namespace Model.Gameplay.Entity
{
    public class Hitbox : Transformer
    {
        [SerializeField] private HealthStorage _healthStorage;
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private Stunned _stunned;
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

        public void TakeHit(int damage, float stunDuration, Vector3 push)
        {
            _healthStorage?.TakeDamage(damage);
            _stunned?.Stun(stunDuration);
            _movable?.SetForce(push, true);
        }
    }

    public enum TargetType
    {
        Player,
        Enemy,
        Destructable
    }

    public enum HarpoonPullMode
    {
        None,
        PullPlayer,
        PullTarget,
    }
}