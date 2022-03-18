using Model.Gameplay.Entity;
using NyarlaEssentials;

namespace Model.Gameplay.Player
{
    public class PlayerComponent : ComponentInstantiator
    {
        private PlayerMarker _marker;
        private PlayerControls _controls;
        private PlayerMovement _movement;
        private PlayerAim _aim;
        private PlayerGun _gun;
        private StateMachine _stateMachine;

        protected PlayerMarker Marker => _marker ??= GetComponent<PlayerMarker>();
        protected PlayerControls Controls => _controls ??= GetComponent<PlayerControls>();
        protected PlayerMovement Movement => _movement ??= GetComponent<PlayerMovement>();
        protected PlayerAim Aim => _aim ??= GetComponent<PlayerAim>();
        protected PlayerGun Gun => _gun ??= GetComponent<PlayerGun>();
        protected StateMachine StateMachine => _stateMachine ??= GetComponent<StateMachine>();
    }
}