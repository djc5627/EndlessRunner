// GENERATED AUTOMATICALLY FROM 'Assets/MyAssets/Scripts/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""fbf29012-d489-450e-bba4-0aa21935cf40"",
            ""actions"": [
                {
                    ""name"": ""MoveInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""58c37a33-347f-4139-b610-e3a6ef114cf6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootPrimary_Press"",
                    ""type"": ""Button"",
                    ""id"": ""e818eae4-c587-49e0-8eea-c7c388fd61b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ShootPrimary_Release"",
                    ""type"": ""Button"",
                    ""id"": ""473e143d-5df9-4b7d-800c-ff67b7cadfb3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ShootSecondary_Press"",
                    ""type"": ""Button"",
                    ""id"": ""31f06326-9c3a-4f99-9a63-2002ea07e5c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ShootSecondary_Release"",
                    ""type"": ""Button"",
                    ""id"": ""7fa03646-2609-4953-adc2-bfe82b3d7639"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Jump_Press"",
                    ""type"": ""Button"",
                    ""id"": ""0abbe66e-166f-40f6-97e4-e3f3c647ec53"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump_Release"",
                    ""type"": ""Button"",
                    ""id"": ""4c6389e8-eb28-4b57-b714-cca2e9059996"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""AimDownSights_Press"",
                    ""type"": ""Button"",
                    ""id"": ""e83205f9-d9d4-4334-85c6-e468c4e0630f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.125)""
                },
                {
                    ""name"": ""AimDownSights_Release"",
                    ""type"": ""Button"",
                    ""id"": ""b7953070-6dae-4b50-9e5c-79040e1aad17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.125,behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""90c01e9c-cb48-47e1-aaba-0dc9fa94e599"",
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
                    ""id"": ""9a42a828-b1f0-4a4b-8ac0-fc3d10b4ccb0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c3a79980-31fa-453b-ab21-f08a1d783d6a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""81f0c725-27c2-48dc-9f58-2d645a05f879"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""47dd6e35-6b06-4cb0-965c-eea6a544c2ae"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c6dc4a41-2cf1-4e59-b575-8fbcdd45e38f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a490fc67-5fd4-470c-882b-861687b825c7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a9e24ecf-222c-4947-a6c0-1f1752b4bf57"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Jump_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fea9335-e4da-4fb9-a547-b5369b9741a6"",
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
                    ""id"": ""62c51c9c-8c55-4fb7-b1e5-e4736bb2eff8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Jump_Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2c89b95-ba0c-465e-803d-dfdb81ca00db"",
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
                    ""id"": ""6c9a5a73-2eb6-45be-8c2c-1c46d8613cf5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ShootPrimary_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""523df1e3-ef9c-466a-878c-b2faadfd5a0d"",
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
                    ""id"": ""8b73ed8c-0de9-4319-8e47-9b33f40bc28c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ShootPrimary_Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d688df2-9981-43b5-a5bf-84942c209c21"",
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
                    ""id"": ""6bb21959-1d3f-4a7e-be77-b7fff3ec5c18"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ShootSecondary_Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b74b4ec2-ca0c-444a-bdca-03b3b6c04e48"",
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
                    ""id"": ""37744a06-8773-464a-91f3-6d74978edc67"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ShootSecondary_Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa9f133f-287e-4028-966e-a3d9ed9a7c68"",
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
                    ""id"": ""e3298ffa-51c5-4fda-84d2-32a4f8e33bd6"",
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
                    ""id"": ""a51e6208-7a75-440d-b513-83d602966b12"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AimDownSights_Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""618b44c0-98a3-4462-8d73-beefa4df95e4"",
            ""actions"": [
                {
                    ""name"": ""JoinGame"",
                    ""type"": ""Button"",
                    ""id"": ""f85fd01c-c5da-4f1e-b846-70e79f57841f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""LeaveGame"",
                    ""type"": ""Button"",
                    ""id"": ""7e905190-e24e-42a3-8a44-8c7b6a7a0ad2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""14ba7f1d-db71-4a70-9bef-17938a186dc7"",
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
                    ""id"": ""dcedf6c0-6ecc-4470-b0c0-0d31309b0d53"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeaveGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveInput = m_Player.FindAction("MoveInput", throwIfNotFound: true);
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
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveInput => m_Wrapper.m_Player_MoveInput;
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
    public struct MenuActions
    {
        private @InputMaster m_Wrapper;
        public MenuActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @JoinGame => m_Wrapper.m_Menu_JoinGame;
        public InputAction @LeaveGame => m_Wrapper.m_Menu_LeaveGame;
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
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveInput(InputAction.CallbackContext context);
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
    }
}
