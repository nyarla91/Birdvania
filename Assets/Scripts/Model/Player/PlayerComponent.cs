using Model.Entity;
using NyarlaEssentials;
using UnityEngine;

namespace Model.Player
{
    public class PlayerComponent : Transformer
    {
        private PlayerMarker _marker;
        private PlayerControls _controls;
        private PlayerMovement _movement;
        private StateMachine _stateMachine;

        protected PlayerMarker Marker => _marker ??= GetComponent<PlayerMarker>();
        protected PlayerControls Controls => _controls ??= GetComponent<PlayerControls>();
        protected PlayerMovement Movement => _movement ??= GetComponent<PlayerMovement>();
        protected StateMachine StateMachine => _stateMachine ??= GetComponent<StateMachine>();
    }
}