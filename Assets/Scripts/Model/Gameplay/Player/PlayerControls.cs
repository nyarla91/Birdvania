using Model.Controls;
using NyarlaEssentials;
using UnityEngine;
using Zenject;

namespace Model.Gameplay.Player
{
    public sealed class PlayerControls : PlayerComponent
    {
        [SerializeField] private MousePlane _mousePlane;
        
        private DeviceUpdateWatcher _deviceUpdateWatcher;
        private GameplayControls _controls;
        private Vector3 _cameraForward;
        private Vector3 _cameraRight;

        private Vector2 ScreenMoveDirection => _controls.General.Move.ReadValue<Vector2>();
        public Vector3 WorldMoveDirection => _cameraForward * ScreenMoveDirection.y + _cameraRight * ScreenMoveDirection.x;
        public Vector3 AimDirection
        {
            get
            {
                if (InputScheme == InputScheme.Gamepad)
                {
                    Vector2 inputVector = _controls.General.RightStickAim.ReadValue<Vector2>();
                    return _cameraForward * inputVector.y + _cameraRight * inputVector.x;
                }
                return (_mousePlane.MousePosition - transform.position).WithY(0).normalized;
            }
        }

        public InputScheme InputScheme => _deviceUpdateWatcher.CurrentInputScheme;

        [Inject]
        private void Construct(GameplayControls controls, DeviceUpdateWatcher deviceUpdateWatcher, CameraProperties cameraProperties)
        {
            _controls = controls;
            _controls.Enable();
            _cameraForward = cameraProperties.transform.forward.WithY(0).normalized;
            _cameraRight = cameraProperties.transform.right.WithY(0).normalized;
            _deviceUpdateWatcher = deviceUpdateWatcher;
        }
    }
}