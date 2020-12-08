// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInput/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""2978ec46-20c8-42ec-b347-f70f7ddc5d20"",
            ""actions"": [
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""85158c46-449c-43b2-ac58-1384eba9b2cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""708a365e-89b2-45c8-9d82-0e2ce40dfaba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireGun"",
                    ""type"": ""Button"",
                    ""id"": ""264b5ae5-8564-4422-9655-9e38831ccaa9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""14e09c13-7756-418c-a3f8-aea1ea680b87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a7ef068-03eb-472d-a5f6-01113cf82694"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a11d1db1-6d95-4a30-ba03-85e69b73e994"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=-1)"",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29076a0f-6b50-4b6d-876b-0fade2e5a23f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=-1)"",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c4eb40a-424a-4543-b260-44dcfe0b6300"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""193e2e73-0959-4e67-bc0f-506bfc40c0aa"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e4d1ec9-69c2-43d2-a4d1-f38fc14607f4"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MoveForward = m_Gameplay.FindAction("MoveForward", throwIfNotFound: true);
        m_Gameplay_MoveRight = m_Gameplay.FindAction("MoveRight", throwIfNotFound: true);
        m_Gameplay_FireGun = m_Gameplay.FindAction("FireGun", throwIfNotFound: true);
        m_Gameplay_Run = m_Gameplay.FindAction("Run", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_MoveForward;
    private readonly InputAction m_Gameplay_MoveRight;
    private readonly InputAction m_Gameplay_FireGun;
    private readonly InputAction m_Gameplay_Run;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveForward => m_Wrapper.m_Gameplay_MoveForward;
        public InputAction @MoveRight => m_Wrapper.m_Gameplay_MoveRight;
        public InputAction @FireGun => m_Wrapper.m_Gameplay_FireGun;
        public InputAction @Run => m_Wrapper.m_Gameplay_Run;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MoveForward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveForward;
                @MoveForward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveForward;
                @MoveForward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveForward;
                @MoveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @FireGun.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireGun;
                @FireGun.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireGun;
                @FireGun.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireGun;
                @Run.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @FireGun.started += instance.OnFireGun;
                @FireGun.performed += instance.OnFireGun;
                @FireGun.canceled += instance.OnFireGun;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMoveForward(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnFireGun(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
}
