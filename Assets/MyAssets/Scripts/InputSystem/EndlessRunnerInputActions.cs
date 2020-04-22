// GENERATED AUTOMATICALLY FROM 'Assets/MyAssets/Scripts/InputSystem/EndlessRunnerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @EndlessRunnerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @EndlessRunnerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EndlessRunnerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b85d5c37-8faa-4f70-93ea-3f2e8c254fcd"",
            ""actions"": [
                {
                    ""name"": ""MoveInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""93cca6fa-f827-4733-9ca1-1d37b4bc5797"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MeleeAttack_Press"",
                    ""type"": ""PassThrough"",
                    ""id"": ""40e457a1-8264-43d6-ac28-27d9a7216a48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RangedAttack_Press"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c5883869-8362-4feb-b9b3-9168cf0c4a9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ShootPrimary_Press"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f31f1eac-4cf6-4f92-82d1-4d979e71b1e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ShootPrimary_Release"",
                    ""type"": ""PassThrough"",
                    ""id"": ""531f98d4-2f8e-4079-990c-1bf131f730e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ShootSecondary_Press"",
                    ""type"": ""PassThrough"",
                    ""id"": ""20492e20-e24c-42ce-8559-20110128395e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ShootSecondary_Release"",
                    ""type"": ""PassThrough"",
                    ""id"": ""73ca9744-edca-4857-a47d-e49e4ee448b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Jump_Press"",
                    ""type"": ""PassThrough"",
                    ""id"": ""15c67ba8-2694-4918-89ac-a4be1a07e6f3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump_Release"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d4be93f6-7f0c-4e72-ac8b-a9846f07d04f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""AimDownSights_Press"",
                    ""type"": ""PassThrough"",
                    ""id"": ""98269e4b-ad49-4b0b-a78b-a7ea5754282d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.125)""
                },
                {
                    ""name"": ""AimDownSights_Release"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dbee6741-4e2e-4715-bab3-a88bc644da21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.125,behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""032670b9-6bcc-4b31-bc5b-122cd9b18c7d"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e70838a8-e1c9-45a2-b765-f9329cf5a4eb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""d9373d5c-a1f8-4ae7-beda-df73d839c783"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""0d1e1732-ac6d-495c-8eea-a84afff3c1c9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""c8b1bb8c-cc98-454c-bdf7-54bc134f21d3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""562dab48-7be8-4040-9e1e-83bab13307be"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""ad257a9c-4b4b-4ebe-be7b-124ff1b13b93"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""38200756-d3f6-41a4-b44c-214a24aa0def"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AimDownSights_Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ccd85c8-1cf1-4eeb-8cb8-17e32ce0b1fe"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShootPrimary_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26784d77-732b-441d-b5e0-aa6f46b12f83"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShootPrimary_Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f1bc33b-9f20-4562-8038-8cd33f956939"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShootSecondary_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a8e5885-f255-4264-88a5-5daa266a8f13"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShootSecondary_Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6be38042-43ca-4227-a178-4932980c28bd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c256e710-5bed-49fa-aed5-5412531efafb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Jump_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4d75c07-b342-4268-baf1-fb9f64908c9b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump_Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a8ad64f-090c-41cb-9b23-b6a5fbde28cf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Jump_Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b33a2360-ae7d-407a-98a9-36fbfce81d26"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AimDownSights_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b8a9995-c67f-402d-9195-9c6b2b95bbfe"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MeleeAttack_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0a2a25a-47a8-4523-8f56-265739bb085d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""MeleeAttack_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e7ff628-f099-4f7b-bc7b-1e14aa3b9fa6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RangedAttack_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da73d102-36fe-415d-a89c-0338d1ee9eb4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""RangedAttack_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""beff10ff-12bd-4879-a0b4-15f863749b27"",
            ""actions"": [
                {
                    ""name"": ""JoinGame"",
                    ""type"": ""Button"",
                    ""id"": ""0bca8c8e-e2f1-4850-9d0d-6b75eea817e6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""LeaveGame"",
                    ""type"": ""Button"",
                    ""id"": ""e79aef9d-c05a-4d42-a399-21cb8e5d12b1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""StartGame"",
                    ""type"": ""Button"",
                    ""id"": ""a90443a5-658a-4155-9d57-21bd22ce09e6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1df90800-b7ce-4908-8309-6d9986aaee05"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab0f7d73-09ff-4126-a96b-7c5a750ffc29"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""JoinGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc7b3c2b-4acb-44cd-a290-8e57e1b1212c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""JoinGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b750b40-8245-4f86-b951-3028ab385041"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeaveGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2540d99-b73e-465a-ac74-e81f224dfda6"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""LeaveGame"",
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
            ""name"": ""Keyboard_Mouse"",
            ""bindingGroup"": ""Keyboard_Mouse"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveInput = m_Player.FindAction("MoveInput", throwIfNotFound: true);
        m_Player_MeleeAttack_Press = m_Player.FindAction("MeleeAttack_Press", throwIfNotFound: true);
        m_Player_RangedAttack_Press = m_Player.FindAction("RangedAttack_Press", throwIfNotFound: true);
        m_Player_ShootPrimary_Press = m_Player.FindAction("ShootPrimary_Press", throwIfNotFound: true);
        m_Player_ShootPrimary_Release = m_Player.FindAction("ShootPrimary_Release", throwIfNotFound: true);
        m_Player_ShootSecondary_Press = m_Player.FindAction("ShootSecondary_Press", throwIfNotFound: true);
        m_Player_ShootSecondary_Release = m_Player.FindAction("ShootSecondary_Release", throwIfNotFound: true);
        m_Player_Jump_Press = m_Player.FindAction("Jump_Press", throwIfNotFound: true);
        m_Player_Jump_Release = m_Player.FindAction("Jump_Release", throwIfNotFound: true);
        m_Player_AimDownSights_Press = m_Player.FindAction("AimDownSights_Press", throwIfNotFound: true);
        m_Player_AimDownSights_Release = m_Player.FindAction("AimDownSights_Release", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_JoinGame = m_Menu.FindAction("JoinGame", throwIfNotFound: true);
        m_Menu_LeaveGame = m_Menu.FindAction("LeaveGame", throwIfNotFound: true);
        m_Menu_StartGame = m_Menu.FindAction("StartGame", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MoveInput;
    private readonly InputAction m_Player_MeleeAttack_Press;
    private readonly InputAction m_Player_RangedAttack_Press;
    private readonly InputAction m_Player_ShootPrimary_Press;
    private readonly InputAction m_Player_ShootPrimary_Release;
    private readonly InputAction m_Player_ShootSecondary_Press;
    private readonly InputAction m_Player_ShootSecondary_Release;
    private readonly InputAction m_Player_Jump_Press;
    private readonly InputAction m_Player_Jump_Release;
    private readonly InputAction m_Player_AimDownSights_Press;
    private readonly InputAction m_Player_AimDownSights_Release;
    public struct PlayerActions
    {
        private @EndlessRunnerInputActions m_Wrapper;
        public PlayerActions(@EndlessRunnerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveInput => m_Wrapper.m_Player_MoveInput;
        public InputAction @MeleeAttack_Press => m_Wrapper.m_Player_MeleeAttack_Press;
        public InputAction @RangedAttack_Press => m_Wrapper.m_Player_RangedAttack_Press;
        public InputAction @ShootPrimary_Press => m_Wrapper.m_Player_ShootPrimary_Press;
        public InputAction @ShootPrimary_Release => m_Wrapper.m_Player_ShootPrimary_Release;
        public InputAction @ShootSecondary_Press => m_Wrapper.m_Player_ShootSecondary_Press;
        public InputAction @ShootSecondary_Release => m_Wrapper.m_Player_ShootSecondary_Release;
        public InputAction @Jump_Press => m_Wrapper.m_Player_Jump_Press;
        public InputAction @Jump_Release => m_Wrapper.m_Player_Jump_Release;
        public InputAction @AimDownSights_Press => m_Wrapper.m_Player_AimDownSights_Press;
        public InputAction @AimDownSights_Release => m_Wrapper.m_Player_AimDownSights_Release;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveInput.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveInput;
                @MoveInput.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveInput;
                @MoveInput.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveInput;
                @MeleeAttack_Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMeleeAttack_Press;
                @MeleeAttack_Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMeleeAttack_Press;
                @MeleeAttack_Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMeleeAttack_Press;
                @RangedAttack_Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangedAttack_Press;
                @RangedAttack_Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangedAttack_Press;
                @RangedAttack_Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangedAttack_Press;
                @ShootPrimary_Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootPrimary_Press;
                @ShootPrimary_Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootPrimary_Press;
                @ShootPrimary_Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootPrimary_Press;
                @ShootPrimary_Release.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootPrimary_Release;
                @ShootPrimary_Release.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootPrimary_Release;
                @ShootPrimary_Release.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootPrimary_Release;
                @ShootSecondary_Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootSecondary_Press;
                @ShootSecondary_Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootSecondary_Press;
                @ShootSecondary_Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootSecondary_Press;
                @ShootSecondary_Release.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootSecondary_Release;
                @ShootSecondary_Release.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootSecondary_Release;
                @ShootSecondary_Release.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootSecondary_Release;
                @Jump_Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump_Press;
                @Jump_Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump_Press;
                @Jump_Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump_Press;
                @Jump_Release.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump_Release;
                @Jump_Release.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump_Release;
                @Jump_Release.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump_Release;
                @AimDownSights_Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDownSights_Press;
                @AimDownSights_Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDownSights_Press;
                @AimDownSights_Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDownSights_Press;
                @AimDownSights_Release.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDownSights_Release;
                @AimDownSights_Release.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDownSights_Release;
                @AimDownSights_Release.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDownSights_Release;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveInput.started += instance.OnMoveInput;
                @MoveInput.performed += instance.OnMoveInput;
                @MoveInput.canceled += instance.OnMoveInput;
                @MeleeAttack_Press.started += instance.OnMeleeAttack_Press;
                @MeleeAttack_Press.performed += instance.OnMeleeAttack_Press;
                @MeleeAttack_Press.canceled += instance.OnMeleeAttack_Press;
                @RangedAttack_Press.started += instance.OnRangedAttack_Press;
                @RangedAttack_Press.performed += instance.OnRangedAttack_Press;
                @RangedAttack_Press.canceled += instance.OnRangedAttack_Press;
                @ShootPrimary_Press.started += instance.OnShootPrimary_Press;
                @ShootPrimary_Press.performed += instance.OnShootPrimary_Press;
                @ShootPrimary_Press.canceled += instance.OnShootPrimary_Press;
                @ShootPrimary_Release.started += instance.OnShootPrimary_Release;
                @ShootPrimary_Release.performed += instance.OnShootPrimary_Release;
                @ShootPrimary_Release.canceled += instance.OnShootPrimary_Release;
                @ShootSecondary_Press.started += instance.OnShootSecondary_Press;
                @ShootSecondary_Press.performed += instance.OnShootSecondary_Press;
                @ShootSecondary_Press.canceled += instance.OnShootSecondary_Press;
                @ShootSecondary_Release.started += instance.OnShootSecondary_Release;
                @ShootSecondary_Release.performed += instance.OnShootSecondary_Release;
                @ShootSecondary_Release.canceled += instance.OnShootSecondary_Release;
                @Jump_Press.started += instance.OnJump_Press;
                @Jump_Press.performed += instance.OnJump_Press;
                @Jump_Press.canceled += instance.OnJump_Press;
                @Jump_Release.started += instance.OnJump_Release;
                @Jump_Release.performed += instance.OnJump_Release;
                @Jump_Release.canceled += instance.OnJump_Release;
                @AimDownSights_Press.started += instance.OnAimDownSights_Press;
                @AimDownSights_Press.performed += instance.OnAimDownSights_Press;
                @AimDownSights_Press.canceled += instance.OnAimDownSights_Press;
                @AimDownSights_Release.started += instance.OnAimDownSights_Release;
                @AimDownSights_Release.performed += instance.OnAimDownSights_Release;
                @AimDownSights_Release.canceled += instance.OnAimDownSights_Release;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_JoinGame;
    private readonly InputAction m_Menu_LeaveGame;
    private readonly InputAction m_Menu_StartGame;
    public struct MenuActions
    {
        private @EndlessRunnerInputActions m_Wrapper;
        public MenuActions(@EndlessRunnerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @JoinGame => m_Wrapper.m_Menu_JoinGame;
        public InputAction @LeaveGame => m_Wrapper.m_Menu_LeaveGame;
        public InputAction @StartGame => m_Wrapper.m_Menu_StartGame;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @JoinGame.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoinGame;
                @JoinGame.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoinGame;
                @JoinGame.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoinGame;
                @LeaveGame.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeaveGame;
                @LeaveGame.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeaveGame;
                @LeaveGame.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeaveGame;
                @StartGame.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartGame;
                @StartGame.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartGame;
                @StartGame.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartGame;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JoinGame.started += instance.OnJoinGame;
                @JoinGame.performed += instance.OnJoinGame;
                @JoinGame.canceled += instance.OnJoinGame;
                @LeaveGame.started += instance.OnLeaveGame;
                @LeaveGame.performed += instance.OnLeaveGame;
                @LeaveGame.canceled += instance.OnLeaveGame;
                @StartGame.started += instance.OnStartGame;
                @StartGame.performed += instance.OnStartGame;
                @StartGame.canceled += instance.OnStartGame;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_Keyboard_MouseSchemeIndex = -1;
    public InputControlScheme Keyboard_MouseScheme
    {
        get
        {
            if (m_Keyboard_MouseSchemeIndex == -1) m_Keyboard_MouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard_Mouse");
            return asset.controlSchemes[m_Keyboard_MouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveInput(InputAction.CallbackContext context);
        void OnMeleeAttack_Press(InputAction.CallbackContext context);
        void OnRangedAttack_Press(InputAction.CallbackContext context);
        void OnShootPrimary_Press(InputAction.CallbackContext context);
        void OnShootPrimary_Release(InputAction.CallbackContext context);
        void OnShootSecondary_Press(InputAction.CallbackContext context);
        void OnShootSecondary_Release(InputAction.CallbackContext context);
        void OnJump_Press(InputAction.CallbackContext context);
        void OnJump_Release(InputAction.CallbackContext context);
        void OnAimDownSights_Press(InputAction.CallbackContext context);
        void OnAimDownSights_Release(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnJoinGame(InputAction.CallbackContext context);
        void OnLeaveGame(InputAction.CallbackContext context);
        void OnStartGame(InputAction.CallbackContext context);
    }
}
