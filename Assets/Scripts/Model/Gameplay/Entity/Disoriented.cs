using System;
using UnityEngine;

namespace Model.Gameplay.Entity
{
    [RequireComponent(typeof(StateMachine))]
    public class Disoriented : MonoBehaviour
    {
        private StateMachine _stateMachine;

        public StateMachine StateMachine => _stateMachine ??= GetComponent<StateMachine>();
        public void Stun(float duration)
        {
            
        }

        public void Stagger(float duration)
        {
            
        }

        private void Start()
        {
            if (StateMachine.GetState("Stun") == null)
                throw new Exception($"{gameObject.name}'s StateMachine must have \"Stun\" state");
        }
    }

    public enum DisorientationType
    {
        Stun,
        Stagger,
        Freeze
    }
}