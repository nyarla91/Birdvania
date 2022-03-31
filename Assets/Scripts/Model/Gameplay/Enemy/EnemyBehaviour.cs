using System;
using Model.Gameplay.Entity;
using Model.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Model.Gameplay.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        private readonly string[] AggressionRaiseStates = {StateMachine.Regular};
        
        private StateMachine _stateMachine;
        private EnemyMovement _movement;
        private PlayerMarker _player;

        protected StateMachine StateMachine => _stateMachine ??= GetComponent<StateMachine>();
        protected EnemyMovement Movement => _movement ??= GetComponent<EnemyMovement>();
        protected PlayerMarker Player => _player;
        
        protected float Aggression { get; set; }
        protected float AggressionRaiseRate { get; set; }

        [Inject]
        private void Construct(PlayerMarker player)
        {
            _player = player;
        }

        protected virtual void FixedUpdate()
        {
            if (StateMachine.IsCurrentStateOneOf(AggressionRaiseStates))
                Aggression += AggressionRaiseRate * Time.fixedDeltaTime;
        }
    }
}