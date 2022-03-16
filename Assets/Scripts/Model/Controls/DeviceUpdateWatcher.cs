using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Switch;
using Zenject;

namespace Model.Controls
{
    public class DeviceUpdateWatcher : MonoBehaviour
    {
        private DeviceUpdateActions _deviceUpdateActions;
        private InputScheme _currentInputScheme;
        private GamepadModel _currentGamepadModel;


        
        public InputScheme CurrentInputScheme
        {
            get => _currentInputScheme;
            set
            {
                if (value == _currentInputScheme)
                    return;
                _currentInputScheme = value;
                OnInputSchemeChanged?.Invoke(value);
            }
        }
        
        public GamepadModel CurrentGamepadModel
        {
            get => _currentGamepadModel;
            set
            {
                if (value == _currentGamepadModel)
                    return;
                _currentGamepadModel = value;
                OnGamepadModelChanged?.Invoke(value);
            }
        }
        
        public event Action<InputScheme> OnInputSchemeChanged;
        public event Action<GamepadModel> OnGamepadModelChanged;

        [Inject]
        private void Construct(DeviceUpdateActions deviceUpdateActions)
        {
            _deviceUpdateActions = deviceUpdateActions;
            _deviceUpdateActions.General.Enable();
            _deviceUpdateActions.General.Keyboard.started += SwitchToKeyboardMouse;
            _deviceUpdateActions.General.Mouse.started += SwitchToKeyboardMouse;
            _deviceUpdateActions.General.Gamepad.started += SwitchToGamepad;
            _deviceUpdateActions.General.DualShock.started += SwitchToDualshock;
            DontDestroyOnLoad(gameObject);
        }

        private void SwitchToKeyboardMouse(InputAction.CallbackContext context)
        {
            CurrentInputScheme = InputScheme.KeyboardMouse;
        }

        private void SwitchToGamepad(InputAction.CallbackContext context)
        {
            CurrentInputScheme = InputScheme.Gamepad;
        
            Gamepad gamepad = Gamepad.current;
            if (gamepad is DualShockGamepad)
                CurrentGamepadModel = GamepadModel.PlayStation;
            else if (gamepad is SwitchProControllerHID)
                CurrentGamepadModel = GamepadModel.Switch;
            else
                CurrentGamepadModel = GamepadModel.Xbox;
        }

        private void SwitchToDualshock(InputAction.CallbackContext context)
        {
            CurrentInputScheme = InputScheme.Gamepad;
            CurrentGamepadModel = GamepadModel.PlayStation;
        }
    }

    public enum GamepadModel
    {
        PlayStation,
        Xbox,
        Switch
    }

    public enum InputScheme
    {
        KeyboardMouse,
        Gamepad
    }
}
