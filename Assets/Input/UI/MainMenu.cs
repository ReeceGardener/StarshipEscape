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
                    ""name"": ""ConfirmSelection"",
                    ""type"": ""Button"",
                    ""id"": ""35f9cf69-abd0-46c2-93bc-f4561f59510b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3774dcf3-1cc6-4b71-91ba-b937840d735c"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConfirmSelection"",
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
        m_MenuContol_ConfirmSelection = m_MenuContol.FindAction("ConfirmSelection", throwIfNotFound: true);
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
    private readonly InputAction m_MenuContol_ConfirmSelection;
    public struct MenuContolActions
    {
        private @MainMenu m_Wrapper;
        public MenuContolActions(@MainMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @ConfirmSelection => m_Wrapper.m_MenuContol_ConfirmSelection;
        public InputActionMap Get() { return m_Wrapper.m_MenuContol; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuContolActions set) { return set.Get(); }
        public void SetCallbacks(IMenuContolActions instance)
        {
            if (m_Wrapper.m_MenuContolActionsCallbackInterface != null)
            {
                @ConfirmSelection.started -= m_Wrapper.m_MenuContolActionsCallbackInterface.OnConfirmSelection;
                @ConfirmSelection.performed -= m_Wrapper.m_MenuContolActionsCallbackInterface.OnConfirmSelection;
                @ConfirmSelection.canceled -= m_Wrapper.m_MenuContolActionsCallbackInterface.OnConfirmSelection;
            }
            m_Wrapper.m_MenuContolActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ConfirmSelection.started += instance.OnConfirmSelection;
                @ConfirmSelection.performed += instance.OnConfirmSelection;
                @ConfirmSelection.canceled += instance.OnConfirmSelection;
            }
        }
    }
    public MenuContolActions @MenuContol => new MenuContolActions(this);
    public interface IMenuContolActions
    {
        void OnConfirmSelection(InputAction.CallbackContext context);
    }
}
