//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerInputActionMap.inputactions
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

public partial class @PlayerInputActionMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActionMap"",
    ""maps"": [
        {
            ""name"": ""PlayerInputMap"",
            ""id"": ""7c2872b6-1be7-4f11-a732-013bb9e3ef96"",
            ""actions"": [
                {
                    ""name"": ""PlayerMoveInput"",
                    ""type"": ""Value"",
                    ""id"": ""8fa12496-7d2f-4743-a2ce-0bd9d15b098d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PlayerShootInput"",
                    ""type"": ""Button"",
                    ""id"": ""4d860a19-afbd-45e3-8485-39ab891f773c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f9e0dde1-2b17-43e9-b562-822e7639f7d4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMoveInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4b5ee331-23ac-446b-8261-22f43ca6e8fb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aa5dd2f5-0b10-4ba4-a242-b15d2c4ab53b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d2c70535-022c-4229-87e1-0730dd3bb43c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerShootInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInputMap
        m_PlayerInputMap = asset.FindActionMap("PlayerInputMap", throwIfNotFound: true);
        m_PlayerInputMap_PlayerMoveInput = m_PlayerInputMap.FindAction("PlayerMoveInput", throwIfNotFound: true);
        m_PlayerInputMap_PlayerShootInput = m_PlayerInputMap.FindAction("PlayerShootInput", throwIfNotFound: true);
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

    // PlayerInputMap
    private readonly InputActionMap m_PlayerInputMap;
    private List<IPlayerInputMapActions> m_PlayerInputMapActionsCallbackInterfaces = new List<IPlayerInputMapActions>();
    private readonly InputAction m_PlayerInputMap_PlayerMoveInput;
    private readonly InputAction m_PlayerInputMap_PlayerShootInput;
    public struct PlayerInputMapActions
    {
        private @PlayerInputActionMap m_Wrapper;
        public PlayerInputMapActions(@PlayerInputActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMoveInput => m_Wrapper.m_PlayerInputMap_PlayerMoveInput;
        public InputAction @PlayerShootInput => m_Wrapper.m_PlayerInputMap_PlayerShootInput;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInputMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerInputMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerInputMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerInputMapActionsCallbackInterfaces.Add(instance);
            @PlayerMoveInput.started += instance.OnPlayerMoveInput;
            @PlayerMoveInput.performed += instance.OnPlayerMoveInput;
            @PlayerMoveInput.canceled += instance.OnPlayerMoveInput;
            @PlayerShootInput.started += instance.OnPlayerShootInput;
            @PlayerShootInput.performed += instance.OnPlayerShootInput;
            @PlayerShootInput.canceled += instance.OnPlayerShootInput;
        }

        private void UnregisterCallbacks(IPlayerInputMapActions instance)
        {
            @PlayerMoveInput.started -= instance.OnPlayerMoveInput;
            @PlayerMoveInput.performed -= instance.OnPlayerMoveInput;
            @PlayerMoveInput.canceled -= instance.OnPlayerMoveInput;
            @PlayerShootInput.started -= instance.OnPlayerShootInput;
            @PlayerShootInput.performed -= instance.OnPlayerShootInput;
            @PlayerShootInput.canceled -= instance.OnPlayerShootInput;
        }

        public void RemoveCallbacks(IPlayerInputMapActions instance)
        {
            if (m_Wrapper.m_PlayerInputMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerInputMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerInputMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerInputMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerInputMapActions @PlayerInputMap => new PlayerInputMapActions(this);
    public interface IPlayerInputMapActions
    {
        void OnPlayerMoveInput(InputAction.CallbackContext context);
        void OnPlayerShootInput(InputAction.CallbackContext context);
    }
}
