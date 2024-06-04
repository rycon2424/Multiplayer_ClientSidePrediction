//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Scripts/Input/CharacterInput.inputactions
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

public partial class @CharacterInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInput"",
    ""maps"": [
        {
            ""name"": ""PlayerExample"",
            ""id"": ""4c403651-fcce-46e1-9bad-6198234880a8"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""015a8e94-153f-4968-9b35-9c222ac97e1c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ChangeColor"",
                    ""type"": ""Button"",
                    ""id"": ""f6a5164a-5c71-45e8-8ea3-91b0a36678f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""IncreaseScale"",
                    ""type"": ""Button"",
                    ""id"": ""bbed13a7-8d9c-47b8-a84c-76064a4023d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DecreaseScale"",
                    ""type"": ""Button"",
                    ""id"": ""ec46760f-c963-4618-8027-d5762f4bd409"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ComplexStruct"",
                    ""type"": ""Button"",
                    ""id"": ""0b651e9a-9f56-4310-af30-cb67244f08e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Pc"",
                    ""id"": ""1e8575ff-060e-4871-bdb0-d641af54496b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6a063d81-ec8b-4ebe-ba46-fb03a98ce681"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f05bb306-0862-4524-9758-8f225fa72f02"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9c2c2572-3a79-4ec1-a4bc-59192bd623ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6f97274f-0e5f-4dd0-b4f2-8326356acfc4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fddae9d1-2468-4d6d-83d9-c97eaf32a711"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""ChangeColor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0b5b128-85e4-4770-858e-c112c7c3c652"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""IncreaseScale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a929bcbd-95b7-48cb-ab5c-ea5fe3fcc2f4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""DecreaseScale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d69aa181-008a-4792-9d9b-b5754596d911"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ComplexStruct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerWorld"",
            ""id"": ""2441bad8-9423-4576-9404-344c0abdca62"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""834ccf32-d017-4a29-8211-bc2acd4c5076"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""3b533382-f2ab-4724-ac68-690648224c82"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""0be9db6e-5440-4368-a78c-44756952c6a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""97ca77ca-244a-41da-8c45-791f408fc74d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""c62351e9-cec4-4b15-bee2-46056542ece1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""23f7d557-967b-4fd6-9e1c-1c2eaa49cb24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Pc"",
                    ""id"": ""c7d279e3-d6fe-43ba-81c5-9603d0a6168e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""81e8badf-f0c3-40e0-9828-f7e5dd9d61ec"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0cbd82cd-dc5a-44aa-9a69-83fb436a23af"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f438553a-dc76-4855-ad10-a7f0c5e0c1a7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3d8393d6-b432-4a17-927e-736b0c272de5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ExamplePlayer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""09b9a45a-881a-4ca9-89d1-2b3c605246ca"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c81e69c-9333-4807-b3ad-5fa02f6dbcb8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""381b0468-f279-41b5-8538-39e6c4d28386"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""450febce-5083-4485-8b65-efb959a848f7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d527ac0b-1e31-4bca-98f3-9225b156a6e0"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b788db29-19ed-4269-b887-7fcbfb3094fc"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9caefba2-73f4-42c6-ba48-e642455ff60d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerCombat"",
            ""id"": ""e19f2b81-95c3-4d99-a4d0-ed54760f1818"",
            ""actions"": [
                {
                    ""name"": ""Check"",
                    ""type"": ""Button"",
                    ""id"": ""ad593952-4469-420a-b5b6-6e98496de510"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c56561bb-c37f-4346-9a75-c66e359e7827"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Check"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""ExamplePlayer"",
            ""bindingGroup"": ""ExamplePlayer"",
            ""devices"": []
        }
    ]
}");
        // PlayerExample
        m_PlayerExample = asset.FindActionMap("PlayerExample", throwIfNotFound: true);
        m_PlayerExample_Movement = m_PlayerExample.FindAction("Movement", throwIfNotFound: true);
        m_PlayerExample_ChangeColor = m_PlayerExample.FindAction("ChangeColor", throwIfNotFound: true);
        m_PlayerExample_IncreaseScale = m_PlayerExample.FindAction("IncreaseScale", throwIfNotFound: true);
        m_PlayerExample_DecreaseScale = m_PlayerExample.FindAction("DecreaseScale", throwIfNotFound: true);
        m_PlayerExample_ComplexStruct = m_PlayerExample.FindAction("ComplexStruct", throwIfNotFound: true);
        // PlayerWorld
        m_PlayerWorld = asset.FindActionMap("PlayerWorld", throwIfNotFound: true);
        m_PlayerWorld_Movement = m_PlayerWorld.FindAction("Movement", throwIfNotFound: true);
        m_PlayerWorld_Camera = m_PlayerWorld.FindAction("Camera", throwIfNotFound: true);
        m_PlayerWorld_Interact = m_PlayerWorld.FindAction("Interact", throwIfNotFound: true);
        m_PlayerWorld_Jump = m_PlayerWorld.FindAction("Jump", throwIfNotFound: true);
        m_PlayerWorld_Crouch = m_PlayerWorld.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerWorld_Sprint = m_PlayerWorld.FindAction("Sprint", throwIfNotFound: true);
        // PlayerCombat
        m_PlayerCombat = asset.FindActionMap("PlayerCombat", throwIfNotFound: true);
        m_PlayerCombat_Check = m_PlayerCombat.FindAction("Check", throwIfNotFound: true);
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

    // PlayerExample
    private readonly InputActionMap m_PlayerExample;
    private List<IPlayerExampleActions> m_PlayerExampleActionsCallbackInterfaces = new List<IPlayerExampleActions>();
    private readonly InputAction m_PlayerExample_Movement;
    private readonly InputAction m_PlayerExample_ChangeColor;
    private readonly InputAction m_PlayerExample_IncreaseScale;
    private readonly InputAction m_PlayerExample_DecreaseScale;
    private readonly InputAction m_PlayerExample_ComplexStruct;
    public struct PlayerExampleActions
    {
        private @CharacterInput m_Wrapper;
        public PlayerExampleActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerExample_Movement;
        public InputAction @ChangeColor => m_Wrapper.m_PlayerExample_ChangeColor;
        public InputAction @IncreaseScale => m_Wrapper.m_PlayerExample_IncreaseScale;
        public InputAction @DecreaseScale => m_Wrapper.m_PlayerExample_DecreaseScale;
        public InputAction @ComplexStruct => m_Wrapper.m_PlayerExample_ComplexStruct;
        public InputActionMap Get() { return m_Wrapper.m_PlayerExample; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerExampleActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerExampleActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerExampleActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerExampleActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @ChangeColor.started += instance.OnChangeColor;
            @ChangeColor.performed += instance.OnChangeColor;
            @ChangeColor.canceled += instance.OnChangeColor;
            @IncreaseScale.started += instance.OnIncreaseScale;
            @IncreaseScale.performed += instance.OnIncreaseScale;
            @IncreaseScale.canceled += instance.OnIncreaseScale;
            @DecreaseScale.started += instance.OnDecreaseScale;
            @DecreaseScale.performed += instance.OnDecreaseScale;
            @DecreaseScale.canceled += instance.OnDecreaseScale;
            @ComplexStruct.started += instance.OnComplexStruct;
            @ComplexStruct.performed += instance.OnComplexStruct;
            @ComplexStruct.canceled += instance.OnComplexStruct;
        }

        private void UnregisterCallbacks(IPlayerExampleActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @ChangeColor.started -= instance.OnChangeColor;
            @ChangeColor.performed -= instance.OnChangeColor;
            @ChangeColor.canceled -= instance.OnChangeColor;
            @IncreaseScale.started -= instance.OnIncreaseScale;
            @IncreaseScale.performed -= instance.OnIncreaseScale;
            @IncreaseScale.canceled -= instance.OnIncreaseScale;
            @DecreaseScale.started -= instance.OnDecreaseScale;
            @DecreaseScale.performed -= instance.OnDecreaseScale;
            @DecreaseScale.canceled -= instance.OnDecreaseScale;
            @ComplexStruct.started -= instance.OnComplexStruct;
            @ComplexStruct.performed -= instance.OnComplexStruct;
            @ComplexStruct.canceled -= instance.OnComplexStruct;
        }

        public void RemoveCallbacks(IPlayerExampleActions instance)
        {
            if (m_Wrapper.m_PlayerExampleActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerExampleActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerExampleActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerExampleActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerExampleActions @PlayerExample => new PlayerExampleActions(this);

    // PlayerWorld
    private readonly InputActionMap m_PlayerWorld;
    private List<IPlayerWorldActions> m_PlayerWorldActionsCallbackInterfaces = new List<IPlayerWorldActions>();
    private readonly InputAction m_PlayerWorld_Movement;
    private readonly InputAction m_PlayerWorld_Camera;
    private readonly InputAction m_PlayerWorld_Interact;
    private readonly InputAction m_PlayerWorld_Jump;
    private readonly InputAction m_PlayerWorld_Crouch;
    private readonly InputAction m_PlayerWorld_Sprint;
    public struct PlayerWorldActions
    {
        private @CharacterInput m_Wrapper;
        public PlayerWorldActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerWorld_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerWorld_Camera;
        public InputAction @Interact => m_Wrapper.m_PlayerWorld_Interact;
        public InputAction @Jump => m_Wrapper.m_PlayerWorld_Jump;
        public InputAction @Crouch => m_Wrapper.m_PlayerWorld_Crouch;
        public InputAction @Sprint => m_Wrapper.m_PlayerWorld_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_PlayerWorld; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerWorldActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerWorldActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerWorldActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerWorldActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Camera.started += instance.OnCamera;
            @Camera.performed += instance.OnCamera;
            @Camera.canceled += instance.OnCamera;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
        }

        private void UnregisterCallbacks(IPlayerWorldActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Camera.started -= instance.OnCamera;
            @Camera.performed -= instance.OnCamera;
            @Camera.canceled -= instance.OnCamera;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
        }

        public void RemoveCallbacks(IPlayerWorldActions instance)
        {
            if (m_Wrapper.m_PlayerWorldActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerWorldActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerWorldActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerWorldActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerWorldActions @PlayerWorld => new PlayerWorldActions(this);

    // PlayerCombat
    private readonly InputActionMap m_PlayerCombat;
    private List<IPlayerCombatActions> m_PlayerCombatActionsCallbackInterfaces = new List<IPlayerCombatActions>();
    private readonly InputAction m_PlayerCombat_Check;
    public struct PlayerCombatActions
    {
        private @CharacterInput m_Wrapper;
        public PlayerCombatActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Check => m_Wrapper.m_PlayerCombat_Check;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCombat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCombatActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerCombatActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerCombatActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerCombatActionsCallbackInterfaces.Add(instance);
            @Check.started += instance.OnCheck;
            @Check.performed += instance.OnCheck;
            @Check.canceled += instance.OnCheck;
        }

        private void UnregisterCallbacks(IPlayerCombatActions instance)
        {
            @Check.started -= instance.OnCheck;
            @Check.performed -= instance.OnCheck;
            @Check.canceled -= instance.OnCheck;
        }

        public void RemoveCallbacks(IPlayerCombatActions instance)
        {
            if (m_Wrapper.m_PlayerCombatActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerCombatActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerCombatActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerCombatActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerCombatActions @PlayerCombat => new PlayerCombatActions(this);
    private int m_ExamplePlayerSchemeIndex = -1;
    public InputControlScheme ExamplePlayerScheme
    {
        get
        {
            if (m_ExamplePlayerSchemeIndex == -1) m_ExamplePlayerSchemeIndex = asset.FindControlSchemeIndex("ExamplePlayer");
            return asset.controlSchemes[m_ExamplePlayerSchemeIndex];
        }
    }
    public interface IPlayerExampleActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnChangeColor(InputAction.CallbackContext context);
        void OnIncreaseScale(InputAction.CallbackContext context);
        void OnDecreaseScale(InputAction.CallbackContext context);
        void OnComplexStruct(InputAction.CallbackContext context);
    }
    public interface IPlayerWorldActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface IPlayerCombatActions
    {
        void OnCheck(InputAction.CallbackContext context);
    }
}