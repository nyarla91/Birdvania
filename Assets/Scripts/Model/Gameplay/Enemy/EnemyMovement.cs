using System;
using Model.Gameplay.Entity;
using Model.Gameplay.Player;
using Pathfinding;
using UnityEngine;
using UnityEngine.AI;

namespace Model.Gameplay.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private const float PathRecalculationPeriod = 0.5f;
        
        [SerializeField] private float _speed;

        private Movable _movable;
        private StateMachine _stateMachine;
        private Vector3 _destination;
        private Transform _target;
        private AIPath _aiPath;

        private Vector3 Direction => AIPath.desiredVelocity.normalized;
        private Movable Movable => _movable ??= GetComponent<Movable>();
        private StateMachine StateMachine => _stateMachine ??= GetComponent<StateMachine>();

        public AIPath AIPath => _aiPath ??= GetComponent<AIPath>();

        public Transform Target
        {
            get => _target;
            set
            {
                if (value == null)
                    _destination = transform.position;
                _target = value;
            }
        }

        public Vector3 Destination
        {
            get => _destination;
            set
            {
                _target = null;
                _destination = value;
            }
        }

        private void Start()
        {
            State harpoonState = StateMachine.GetState(PlayerHarpoon.HarpoonState);
            harpoonState.OnEnter += EnterHarpoonState;
            harpoonState.OnExit += ExitHarpoonState;
        }

        private void EnterHarpoonState()
        {
            gameObject.layer = 15;
        }
        
        private void ExitHarpoonState()
        {
            gameObject.layer = 7;
        }

        private void FixedUpdate()
        {
            if (Target != null)
                _destination = Target.position;
            AIPath.destination = Destination;
            
            Vector3 velocity = Direction * _speed * Time.fixedDeltaTime;
            Movable.Move(velocity, false, false);
        }
    }
}