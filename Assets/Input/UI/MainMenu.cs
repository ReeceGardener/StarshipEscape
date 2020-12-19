// GENERATED AUTOMATICALLY FROM 'Assets/Input/UI/MainMenu.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainMenu : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainMenu()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainMenu"",
    ""maps"": [
        {
            ""name"": ""MenuContol"",
            ""id"": ""7be4416b-e4cb-412b-8239-1439abde28d1"",
            ""actions"": [
                {
                    ""name"": ""MoveSelection"",
                    ""type"": ""Button"",
                    ""id"": ""7b19d1e4-3235-4ea0-9069-4dda304cb825"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""32a6f68b-013e-4a0c-b364-dfc6b6e315b9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=-1)"",
                    ""groups"": """",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed637c4c-3196-4e77-8493-730ab2e32232"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": """",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MenuContol
        m_MenuContol = asset.FindActionMap("MenuContol", throwIfNotFound: true);
        m_MenuContol_MoveSelection = m_MenuContol.FindAction("MoveSelection", throwIfNotFound: true);
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

    // MenuContol
    private readonly InputActionMap m_MenuContol;
    private IMenuContolActions m_MenuContolActionsCallbackInterface;
    private readonly InputAction m_MenuContol_MoveSelection;
    public struct MenuContolActions
    {
        private @MainMenu m_Wrapper;
        public MenuContolActions(@MainMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveSelection => m_Wrapper.m_MenuContol_MoveSelection;
        public InputActionMap Get() { return m_Wrapper.m_MenuContol; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuContolActions set) { return set.Get(); }
        public void SetCallbacks(IMenuContolActions instance)
        {
            if (m_Wrapper.m_MenuContolActionsCallbackInterface != null)
            {
                @MoveSelection.started -= m_Wrapper.m_MenuContolActionsCallbackInterface.OnMoveSelection;
                @MoveSelection.performed -= m_Wrapper.m_MenuContolActionsCallbackInterface.OnMoveSelection;
                @MoveSelection.canceled -= m_Wrapper.m_MenuContolActionsCallbackInterface.OnMoveSelection;
            }
            m_Wrapper.m_MenuContolActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveSelection.started += instance.OnMoveSelection;
                @MoveSelection.performed += instance.OnMoveSelection;
                @MoveSelection.canceled += instance.OnMoveSelection;
            }
        }
    }
    public MenuContolActions @MenuContol => new MenuContolActions(this);
    public interface IMenuContolActions
    {
        void OnMoveSelection(InputAction.CallbackContext context);
    }
}
