using System;
using Model.Player;
using NyarlaEssentials;
using UnityEngine;
using Zenject;

namespace Model.Controls
{
    public class MousePlane : Transformer
    {
        private GameplayControls _controls;
        private CameraProperties _cameraProperties;

        public Vector3 MousePosition { get; private set; }
        
        [Inject]
        private void Construct(GameplayControls controls, CameraProperties cameraProperties)
        {
            _controls = controls;
            _cameraProperties = cameraProperties;
        }

        private void Update()
        {
            UpdateMousePosition();
        }

        private void UpdateMousePosition()
        {
            Vector2 screenMousePosition = _controls.General.Mouse.ReadValue<Vector2>();
            Ray ray = _cameraProperties.Main.ScreenPointToRay(screenMousePosition);
            LayerMask layerMask = LayerMask.GetMask("MousePlane");
            
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Single.MaxValue, layerMask))
            {
                MousePosition = raycastHit.point;
            }
        }
    }
}