//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/Model/Controls/GameplayControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameplayControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameplayControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameplayControls"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""05ab3beb-cc38-4975-b702-98f34b6fa6eb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""31dc400d-d165-476c-a172-5ca4179cff7d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RollGlide"",
                    ""type"": ""Button"",
                    ""id"": ""4706f29a-92ed-4ef9-a511-ff197016bea4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""8f9497e6-88ea-46d1-b84f-bb07f3ff786d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""8c42c2c6-df8b-48dd-8382-7118e407eae4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RightStickAim"",
                    ""type"": ""Value"",
                    ""id"": ""8a4b2ace-8f19-4b75-a90e-fdafc06c8f75"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b1e377e8-c467-4759-989f-fd40024ac57d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""5fc39131-1ddf-45de-863f-9a6a9a7257df"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""48673022-faed-4f70-8bf9-ac445d767846"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f2171d63-8440-409b-bbfc-149249ba0bc5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1976c480-ae89-4886-ad79-097edc6ad17a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c50514b3-420a-43ac-a418-75e5aa5cf96b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6962b80e-ae91-4d11-a94d-9fdacf8c7d15"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RollGlide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49fbf699-be46-47c9-97ed-4331d5e65719"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""RollGlide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90b9d604-b717-48e6-9cd9-35b81fbf3e9f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d93f06a-b2e4-4bd0-82e2-6cc323e78b22"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a64f3aa1-7bc3-45e6-8bca-daf3caca6994"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0081d39-d117-41d3-89f5-1efb1b452642"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9d6afd5-06f0-46d1-8a50-9a6117260e17"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a057d44a-e606-4756-b701-438c172f5291"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fa0abfc-c92a-4399-be2b-1b549f1ae02f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStickAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Regular"",
            ""id"": ""1599ba35-11b7-40e7-a1e9-e6e5b09ce6b3"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""6bde8e62-fc55-4681-b03b-ef03694f1991"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""d64d65dc-dae9-45e3-b74c-18040bc19dee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cd0fb01d-a388-4a5b-8a15-d1cf0290769d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02eef959-3139-4d49-814d-28b779bda53a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43790b97-aa2a-477a-9950-584dd6453b00"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6312fab7-e3c2-4e13-8a7d-f6d27f34d1ad"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Aim"",
            ""id"": ""81dda5a9-5a63-4485-9861-061e89691f5d"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""4abe1f74-411c-42d2-8f9f-cc2e3dc9e6f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Harpoon"",
                    ""type"": ""Button"",
                    ""id"": ""c7595e8c-2892-44aa-b496-fbdaee3b1762"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""73af4fc0-cf36-4714-9059-30c1c3d20b11"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold(duration=0.25)"",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06eebbd0-5d9d-4e5a-9016-26aeb735425e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold(duration=0.25)"",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4535e56a-8eda-4c54-be60-6a60f0528ffd"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Harpoon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""817ba869-ad4d-480a-818f-86aca322228c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Harpoon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_Move = m_General.FindAction("Move", throwIfNotFound: true);
        m_General_RollGlide = m_General.FindAction("RollGlide", throwIfNotFound: true);
        m_General_Aim = m_General.FindAction("Aim", throwIfNotFound: true);
        m_General_Mouse = m_General.FindAction("Mouse", throwIfNotFound: true);
        m_General_RightStickAim = m_General.FindAction("RightStickAim", throwIfNotFound: true);
        // Regular
        m_Regular = asset.FindActionMap("Regular", throwIfNotFound: true);
        m_Regular_Attack = m_Regular.FindAction("Attack", throwIfNotFound: true);
        m_Regular_Block = m_Regular.FindAction("Block", throwIfNotFound: true);
        // Aim
        m_Aim = asset.FindActionMap("Aim", throwIfNotFound: true);
        m_Aim_Shoot = m_Aim.FindAction("Shoot", throwIfNotFound: true);
        m_Aim_Harpoon = m_Aim.FindAction("Harpoon", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_Move;
    private readonly InputAction m_General_RollGlide;
    private readonly InputAction m_General_Aim;
    private readonly InputAction m_General_Mouse;
    private readonly InputAction m_General_RightStickAim;
    public struct GeneralActions
    {
        private @GameplayControls m_Wrapper;
        public GeneralActions(@GameplayControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_General_Move;
        public InputAction @RollGlide => m_Wrapper.m_General_RollGlide;
        public InputAction @Aim => m_Wrapper.m_General_Aim;
        public InputAction @Mouse => m_Wrapper.m_General_Mouse;
        public InputAction @RightStickAim => m_Wrapper.m_General_RightStickAim;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                @RollGlide.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnRollGlide;
                @RollGlide.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnRollGlide;
                @RollGlide.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnRollGlide;
                @Aim.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnAim;
                @Mouse.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMouse;
                @RightStickAim.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnRightStickAim;
                @RightStickAim.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnRightStickAim;
                @RightStickAim.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnRightStickAim;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @RollGlide.started += instance.OnRollGlide;
                @RollGlide.performed += instance.OnRollGlide;
                @RollGlide.canceled += instance.OnRollGlide;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @RightStickAim.started += instance.OnRightStickAim;
                @RightStickAim.performed += instance.OnRightStickAim;
                @RightStickAim.canceled += instance.OnRightStickAim;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);

    // Regular
    private readonly InputActionMap m_Regular;
    private IRegularActions m_RegularActionsCallbackInterface;
    private readonly InputAction m_Regular_Attack;
    private readonly InputAction m_Regular_Block;
    public struct RegularActions
    {
        private @GameplayControls m_Wrapper;
        public RegularActions(@GameplayControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Regular_Attack;
        public InputAction @Block => m_Wrapper.m_Regular_Block;
        public InputActionMap Get() { return m_Wrapper.m_Regular; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RegularActions set) { return set.Get(); }
        public void SetCallbacks(IRegularActions instance)
        {
            if (m_Wrapper.m_RegularActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_RegularActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_RegularActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_RegularActionsCallbackInterface.OnAttack;
                @Block.started -= m_Wrapper.m_RegularActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_RegularActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_RegularActionsCallbackInterface.OnBlock;
            }
            m_Wrapper.m_RegularActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
            }
        }
    }
    public RegularActions @Regular => new RegularActions(this);

    // Aim
    private readonly InputActionMap m_Aim;
    private IAimActions m_AimActionsCallbackInterface;
    private readonly InputAction m_Aim_Shoot;
    private readonly InputAction m_Aim_Harpoon;
    public struct AimActions
    {
        private @GameplayControls m_Wrapper;
        public AimActions(@GameplayControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Aim_Shoot;
        public InputAction @Harpoon => m_Wrapper.m_Aim_Harpoon;
        public InputActionMap Get() { return m_Wrapper.m_Aim; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AimActions set) { return set.Get(); }
        public void SetCallbacks(IAimActions instance)
        {
            if (m_Wrapper.m_AimActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_AimActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_AimActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_AimActionsCallbackInterface.OnShoot;
                @Harpoon.started -= m_Wrapper.m_AimActionsCallbackInterface.OnHarpoon;
                @Harpoon.performed -= m_Wrapper.m_AimActionsCallbackInterface.OnHarpoon;
                @Harpoon.canceled -= m_Wrapper.m_AimActionsCallbackInterface.OnHarpoon;
            }
            m_Wrapper.m_AimActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Harpoon.started += instance.OnHarpoon;
                @Harpoon.performed += instance.OnHarpoon;
                @Harpoon.canceled += instance.OnHarpoon;
            }
        }
    }
    public AimActions @Aim => new AimActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IGeneralActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRollGlide(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnRightStickAim(InputAction.CallbackContext context);
    }
    public interface IRegularActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
    }
    public interface IAimActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnHarpoon(InputAction.CallbackContext context);
    }
}
