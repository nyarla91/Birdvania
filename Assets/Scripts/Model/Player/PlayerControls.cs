using Model.Controls;
using NyarlaEssentials;
using UnityEngine;
using Zenject;

namespace Model.Player
{
    public sealed class PlayerControls : PlayerComponent
    {
        [SerializeField] private MousePlane _mousePlane;
        
        private DeviceUpdateWatcher _deviceUpdateWatcher;
        private GameplayControls _controls;
        private Vector3 _cameraForward;
        private Vector3 _cameraRight;

        public Vector2 ScreenMoveVector => _controls.General.Move.ReadValue<Vector2>();
        public Vector3 WorldMoveVector => _cameraForward * ScreenMoveVector.y + _cameraRight * ScreenMoveVector.x;
        public Vector3 MouseDirection => (_mousePlane.MousePosition - transform.position).WithY(0).normalized;

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