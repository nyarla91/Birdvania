using System;
using System.Collections;
using System.Collections.Generic;
using NyarlaEssentials;
using UnityEngine;

namespace Model.Gameplay.Entity
{
    [RequireComponent(typeof(StateMachine))]
    public class MeleeAttack : Transformer
    {
        [SerializeField] private List<Attack> _attacks;

        private StateMachine _stateMachine;
        private Movable _movable;
        private Coroutine _attackCoroutine;

        public StateMachine StateMachine => _stateMachine ??= GetComponent<StateMachine>();
        public Movable Movable => _movable ??= GetComponent<Movable>();
        
        public void PerformAttack(int attackIndex)
        {
            if (attackIndex >= _attacks.Count)
                throw new Exception($"{gameObject.name} has no attack of index {attackIndex}");

            if (!StateMachine.TrySwitchToState("Attack"))
                return;
            _attackCoroutine = StartCoroutine(PerformingAttack(_attacks[attackIndex]));
        }

        private IEnumerator PerformingAttack(Attack performedAttack)
        {
            yield return new WaitForSeconds(performedAttack.SwingDuration);
            
            List<Hitbox> targets = performedAttack.Area.Targets;
            foreach (var target in targets)
            {
                Vector3 pushForce = target.transform.position - transform.position;
                pushForce *= performedAttack.TargetPushForce;
                pushForce = pushForce.WithY(0).normalized;
                target.TakeHit(performedAttack.Damage, performedAttack.StunTime, pushForce);
            }
            Movable?.SetForce(performedAttack.AttackerPushForce * transform.forward, false);
            
            yield return new WaitForSeconds(performedAttack.RestoreDuration);
            StopAttack();
        }

        private void StopAttack()
        {
            if (!StateMachine.IsCurrentState(StateMachine.Attack))
                return;
            
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
            StateMachine.TrySwitchToState(StateMachine.Regular);
        }

        private void Start()
        {
            if (StateMachine.GetState(StateMachine.Attack) == null)
                throw new Exception($"{gameObject.name}'s StateMachine must have \"Attack\" state");
            StateMachine.GetState(StateMachine.Attack).OnExit += StopAttack;
        }
    }
    
    [Serializable]
    public class Attack
    {
        [SerializeField] private float _swingDuration;
        [SerializeField] private float _restoreDuration;
        [SerializeField] private int _damage;
        [SerializeField] private float _attackerPushForce;
        [SerializeField] private float _targetPushForce;
        [SerializeField] private float _stunTime;
        [SerializeField] private MeleeAttackArea area;

        public float SwingDuration => _swingDuration;
        public float RestoreDuration => _restoreDuration;
        public int Damage => _damage;
        public float AttackerPushForce => _attackerPushForce;
        public float TargetPushForce => _targetPushForce;
        public float StunTime => _stunTime;
        public MeleeAttackArea Area => area;
    }
}