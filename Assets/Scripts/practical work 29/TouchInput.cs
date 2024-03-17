//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/practical work/TouchInput.inputactions
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

public partial class @TouchInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchInput"",
    ""maps"": [
        {
            ""name"": ""ScreenInput"",
            ""id"": ""fd251c34-7cb6-4c7e-aa14-304549896ae2"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""14f3fd3f-f7ae-4869-88f7-337a0c3a6e9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7dbff5ec-73c5-4ef0-99cc-ea0d046a2c4b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8958275c-9886-4579-ab77-fbd91b0fb521"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b0c449c-4814-4530-961e-9349f5a1c362"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Approximation"",
            ""id"": ""61d1998d-2ec6-4994-88fa-2b39cb9ea0ef"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""55946d3c-61d8-4659-82e8-e6fec8e4f0ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Delta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""345ce6d7-00e5-4ef8-92cd-e15004865ad2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EndPositionFirstTouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""892afaf5-8c0f-4e5f-bc6a-7bb41657d9d3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EndPositionSecondTouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""61efe887-1a60-40d0-a6c0-2d0a2fd5083b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b7853e9-e7a9-45a1-b81a-1285f14ce68f"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0508e1d2-af74-426e-acec-60a219d79993"",
                    ""path"": ""<Touchscreen>/touch0/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdf1b665-fd65-4357-aeb5-a1fec6b51603"",
                    ""path"": ""<Touchscreen>/touch1/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebd3835b-f71c-48a8-9614-1e994861dbfd"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EndPositionFirstTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67a93ff3-ae50-40f3-866b-497c182b1a20"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EndPositionSecondTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ScreenInput
        m_ScreenInput = asset.FindActionMap("ScreenInput", throwIfNotFound: true);
        m_ScreenInput_Touch = m_ScreenInput.FindAction("Touch", throwIfNotFound: true);
        m_ScreenInput_TouchPosition = m_ScreenInput.FindAction("TouchPosition", throwIfNotFound: true);
        // Approximation
        m_Approximation = asset.FindActionMap("Approximation", throwIfNotFound: true);
        m_Approximation_Touch = m_Approximation.FindAction("Touch", throwIfNotFound: true);
        m_Approximation_Delta = m_Approximation.FindAction("Delta", throwIfNotFound: true);
        m_Approximation_EndPositionFirstTouch = m_Approximation.FindAction("EndPositionFirstTouch", throwIfNotFound: true);
        m_Approximation_EndPositionSecondTouch = m_Approximation.FindAction("EndPositionSecondTouch", throwIfNotFound: true);
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

    // ScreenInput
    private readonly InputActionMap m_ScreenInput;
    private List<IScreenInputActions> m_ScreenInputActionsCallbackInterfaces = new List<IScreenInputActions>();
    private readonly InputAction m_ScreenInput_Touch;
    private readonly InputAction m_ScreenInput_TouchPosition;
    public struct ScreenInputActions
    {
        private @TouchInput m_Wrapper;
        public ScreenInputActions(@TouchInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_ScreenInput_Touch;
        public InputAction @TouchPosition => m_Wrapper.m_ScreenInput_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_ScreenInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ScreenInputActions set) { return set.Get(); }
        public void AddCallbacks(IScreenInputActions instance)
        {
            if (instance == null || m_Wrapper.m_ScreenInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ScreenInputActionsCallbackInterfaces.Add(instance);
            @Touch.started += instance.OnTouch;
            @Touch.performed += instance.OnTouch;
            @Touch.canceled += instance.OnTouch;
            @TouchPosition.started += instance.OnTouchPosition;
            @TouchPosition.performed += instance.OnTouchPosition;
            @TouchPosition.canceled += instance.OnTouchPosition;
        }

        private void UnregisterCallbacks(IScreenInputActions instance)
        {
            @Touch.started -= instance.OnTouch;
            @Touch.performed -= instance.OnTouch;
            @Touch.canceled -= instance.OnTouch;
            @TouchPosition.started -= instance.OnTouchPosition;
            @TouchPosition.performed -= instance.OnTouchPosition;
            @TouchPosition.canceled -= instance.OnTouchPosition;
        }

        public void RemoveCallbacks(IScreenInputActions instance)
        {
            if (m_Wrapper.m_ScreenInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IScreenInputActions instance)
        {
            foreach (var item in m_Wrapper.m_ScreenInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ScreenInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ScreenInputActions @ScreenInput => new ScreenInputActions(this);

    // Approximation
    private readonly InputActionMap m_Approximation;
    private List<IApproximationActions> m_ApproximationActionsCallbackInterfaces = new List<IApproximationActions>();
    private readonly InputAction m_Approximation_Touch;
    private readonly InputAction m_Approximation_Delta;
    private readonly InputAction m_Approximation_EndPositionFirstTouch;
    private readonly InputAction m_Approximation_EndPositionSecondTouch;
    public struct ApproximationActions
    {
        private @TouchInput m_Wrapper;
        public ApproximationActions(@TouchInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_Approximation_Touch;
        public InputAction @Delta => m_Wrapper.m_Approximation_Delta;
        public InputAction @EndPositionFirstTouch => m_Wrapper.m_Approximation_EndPositionFirstTouch;
        public InputAction @EndPositionSecondTouch => m_Wrapper.m_Approximation_EndPositionSecondTouch;
        public InputActionMap Get() { return m_Wrapper.m_Approximation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ApproximationActions set) { return set.Get(); }
        public void AddCallbacks(IApproximationActions instance)
        {
            if (instance == null || m_Wrapper.m_ApproximationActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ApproximationActionsCallbackInterfaces.Add(instance);
            @Touch.started += instance.OnTouch;
            @Touch.performed += instance.OnTouch;
            @Touch.canceled += instance.OnTouch;
            @Delta.started += instance.OnDelta;
            @Delta.performed += instance.OnDelta;
            @Delta.canceled += instance.OnDelta;
            @EndPositionFirstTouch.started += instance.OnEndPositionFirstTouch;
            @EndPositionFirstTouch.performed += instance.OnEndPositionFirstTouch;
            @EndPositionFirstTouch.canceled += instance.OnEndPositionFirstTouch;
            @EndPositionSecondTouch.started += instance.OnEndPositionSecondTouch;
            @EndPositionSecondTouch.performed += instance.OnEndPositionSecondTouch;
            @EndPositionSecondTouch.canceled += instance.OnEndPositionSecondTouch;
        }

        private void UnregisterCallbacks(IApproximationActions instance)
        {
            @Touch.started -= instance.OnTouch;
            @Touch.performed -= instance.OnTouch;
            @Touch.canceled -= instance.OnTouch;
            @Delta.started -= instance.OnDelta;
            @Delta.performed -= instance.OnDelta;
            @Delta.canceled -= instance.OnDelta;
            @EndPositionFirstTouch.started -= instance.OnEndPositionFirstTouch;
            @EndPositionFirstTouch.performed -= instance.OnEndPositionFirstTouch;
            @EndPositionFirstTouch.canceled -= instance.OnEndPositionFirstTouch;
            @EndPositionSecondTouch.started -= instance.OnEndPositionSecondTouch;
            @EndPositionSecondTouch.performed -= instance.OnEndPositionSecondTouch;
            @EndPositionSecondTouch.canceled -= instance.OnEndPositionSecondTouch;
        }

        public void RemoveCallbacks(IApproximationActions instance)
        {
            if (m_Wrapper.m_ApproximationActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IApproximationActions instance)
        {
            foreach (var item in m_Wrapper.m_ApproximationActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ApproximationActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ApproximationActions @Approximation => new ApproximationActions(this);
    public interface IScreenInputActions
    {
        void OnTouch(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
    public interface IApproximationActions
    {
        void OnTouch(InputAction.CallbackContext context);
        void OnDelta(InputAction.CallbackContext context);
        void OnEndPositionFirstTouch(InputAction.CallbackContext context);
        void OnEndPositionSecondTouch(InputAction.CallbackContext context);
    }
}