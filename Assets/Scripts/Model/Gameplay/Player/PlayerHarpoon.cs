using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Model.Gameplay.Player
{
    public class PlayerHarpoon : PlayerComponent
    {
        public const string HarpoonState = "Harpoon";
        
        private GameplayControls _controls;

        [Inject]
        private void Construct(GameplayControls controls)
        {
            _controls = controls;
            _controls.Aim.Harpoon.canceled += HarpoonPressed;
        }

        private void HarpoonPressed(InputAction.CallbackContext context)
        {
            if (StateMachine.TrySwitchToState(HarpoonState))
            {
                
            }
        }
    }
}