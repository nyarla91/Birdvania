using System;
using System.Collections.Generic;
using Model.Gameplay.Entity;
using NyarlaEssentials;
using UnityEngine;

namespace Presenter.Gameplay.Enemy
{
    public class EnemyStateSignal : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private SerializedDictionary<string, Material> _signals;

        private void FixedUpdate()
        {
            string currentState = _stateMachine.CurrentState.Name;
            print($"{currentState} ? {_signals.Dictionary.ContainsKey(currentState)}");
            if (_signals.Dictionary.ContainsKey(currentState))
            {
                _renderer.material = _signals.Dictionary[currentState];
            }
        }
    }
}