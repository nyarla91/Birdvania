using System;
using UnityEngine;

namespace Model.Entity
{
    [RequireComponent(typeof(StateMachine))]
    public class Stunned : MonoBehaviour
    {
        private StateMachine _stateMachine;

        public StateMachine StateMachine => _stateMachine ??= GetComponent<StateMachine>();
        public void Stun(float duration)
        {
            
        }

        private void Start()
        {
            if (StateMachine.GetState("Stun") == null)
                throw new Exception($"{gameObject.name}'s StateMachine must have \"Stun\" state");
        }
    }
}