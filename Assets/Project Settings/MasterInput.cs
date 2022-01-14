// GENERATED AUTOMATICALLY FROM 'Assets/Project Settings/MasterInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MasterInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MasterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""4d881ea4-fcc1-4144-b0a5-8df8a5526371"",
            ""actions"": [
                {
                    ""name"": ""Primary Stick"",
                    ""type"": ""Value"",
                    ""id"": ""5f7a07dd-1bca-403d-8342-0422fdfdc1b3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary Stick"",
                    ""type"": ""Value"",
                    ""id"": ""111a4726-60b8-4697-9a8b-afd90cf364db"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Trigger"",
                    ""type"": ""Value"",
                    ""id"": ""c91d0b7f-f121-4b56-9606-4e0900d7f76d"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Trigger"",
                    ""type"": ""Value"",
                    ""id"": ""3008f554-9003-4b5d-bc26-27aeabbbdbec"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Grip"",
                    ""type"": ""Value"",
                    ""id"": ""b887bc7e-6b0e-4ea2-8751-e8fb837dd1e4"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Grip"",
                    ""type"": ""Value"",
                    ""id"": ""b83e34fe-8bdd-4222-8a03-d089ff3e784d"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button A"",
                    ""type"": ""Button"",
                    ""id"": ""8e5e2ace-fe5e-4aa3-b421-1545a7359622"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button B"",
                    ""type"": ""Button"",
                    ""id"": ""2344d655-8479-415b-9023-75aba39e5991"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button X"",
                    ""type"": ""Button"",
                    ""id"": ""5cd13ba3-27af-4708-b4e9-f88c3e5276cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button Y"",
                    ""type"": ""Button"",
                    ""id"": ""5145a9f2-df79-4c8b-a790-fad05bc6c6e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Open Programming"",
                    ""type"": ""Button"",
                    ""id"": ""a153607a-fb16-4a3d-bae8-4a9369450c3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0cd6a7c3-621c-4b50-9955-3b5659b3df06"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Stick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dd4180dc-ab9a-488c-9d6c-615b983ad665"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Primary Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1accae52-6c67-40fa-b74b-4d34779a2aa1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Primary Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b9aa724a-0b19-49f9-a07f-03efb3942b83"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Primary Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0246b2e1-4c60-40b2-a8ee-7f4dccfe6742"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Primary Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f8437513-3f82-441c-9234-2a6786096c90"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Primary Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61417169-76b7-4297-88d1-07a72bc1ac4a"",
                    ""path"": ""<XRController>{LeftHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Primary Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""764a27be-9b87-4472-b294-1a868eb2df98"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Secondary Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30805239-0406-434f-a170-6ebe6615eb85"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Secondary Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dd727af-d0d2-4a6b-a6a6-5b987151c01b"",
                    ""path"": ""<XRController>{RightHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Secondary Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""771dc64a-8251-4131-845a-e494e6ca2062"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Left Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""628798bc-dcca-4360-b448-124b5141ddd5"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Left Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""533ab0c0-a78f-4b38-89ab-347172ff7144"",
                    ""path"": ""<XRController>{LeftHand}/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Left Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7f21199-fa28-410f-8a43-771892c5db66"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Right Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8865b772-e8ed-41d1-b693-eb2ae29ed0d2"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Right Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ad92102-3382-49c8-8f8c-0d71e8b65813"",
                    ""path"": ""<XRController>{RightHand}/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Right Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f399457-6b59-4654-9c9d-402b77664620"",
                    ""path"": ""<XRController>{LeftHand}/grip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Left Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae2cf43c-d8b2-4ae2-9c39-0fbfa2c09953"",
                    ""path"": ""<XRController>{RightHand}/grip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Right Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8293620-9d2e-4feb-8c27-cc7c4eaa9f2c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ef4f2b2-e992-4f12-aab3-421f8887cdcd"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Button A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1e66145-418f-414e-a91c-8a1f2b19e947"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77ef64f7-0841-4281-81ef-eec94bdde017"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Button B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14b05fbc-d6c4-4d91-a7a9-f99115cee8ec"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6da578e-94df-41a9-bd7c-2b9516206765"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcbeab52-8d1a-4280-962f-8c37f7347cad"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cab6b24-4714-4ae8-b6a4-f4d9a30030b8"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Button Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""791ded0c-0435-4dc6-91c4-fd35213a1632"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Open Programming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4314bc3-d7e1-4d6b-b09c-e8e992b92f44"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Open Programming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c778741-c7f9-4622-9495-f61036242e50"",
                    ""path"": ""<XRController>{LeftHand}/menu"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""VR"",
                    ""action"": ""Open Programming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
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
        },
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
            ""name"": ""VR"",
            ""bindingGroup"": ""VR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRHMD>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRController>{LeftHand}"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRController>{RightHand}"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_PrimaryStick = m_Gameplay.FindAction("Primary Stick", throwIfNotFound: true);
        m_Gameplay_SecondaryStick = m_Gameplay.FindAction("Secondary Stick", throwIfNotFound: true);
        m_Gameplay_LeftTrigger = m_Gameplay.FindAction("Left Trigger", throwIfNotFound: true);
        m_Gameplay_RightTrigger = m_Gameplay.FindAction("Right Trigger", throwIfNotFound: true);
        m_Gameplay_LeftGrip = m_Gameplay.FindAction("Left Grip", throwIfNotFound: true);
        m_Gameplay_RightGrip = m_Gameplay.FindAction("Right Grip", throwIfNotFound: true);
        m_Gameplay_ButtonA = m_Gameplay.FindAction("Button A", throwIfNotFound: true);
        m_Gameplay_ButtonB = m_Gameplay.FindAction("Button B", throwIfNotFound: true);
        m_Gameplay_ButtonX = m_Gameplay.FindAction("Button X", throwIfNotFound: true);
        m_Gameplay_ButtonY = m_Gameplay.FindAction("Button Y", throwIfNotFound: true);
        m_Gameplay_OpenProgramming = m_Gameplay.FindAction("Open Programming", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_PrimaryStick;
    private readonly InputAction m_Gameplay_SecondaryStick;
    private readonly InputAction m_Gameplay_LeftTrigger;
    private readonly InputAction m_Gameplay_RightTrigger;
    private readonly InputAction m_Gameplay_LeftGrip;
    private readonly InputAction m_Gameplay_RightGrip;
    private readonly InputAction m_Gameplay_ButtonA;
    private readonly InputAction m_Gameplay_ButtonB;
    private readonly InputAction m_Gameplay_ButtonX;
    private readonly InputAction m_Gameplay_ButtonY;
    private readonly InputAction m_Gameplay_OpenProgramming;
    public struct GameplayActions
    {
        private @MasterInput m_Wrapper;
        public GameplayActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryStick => m_Wrapper.m_Gameplay_PrimaryStick;
        public InputAction @SecondaryStick => m_Wrapper.m_Gameplay_SecondaryStick;
        public InputAction @LeftTrigger => m_Wrapper.m_Gameplay_LeftTrigger;
        public InputAction @RightTrigger => m_Wrapper.m_Gameplay_RightTrigger;
        public InputAction @LeftGrip => m_Wrapper.m_Gameplay_LeftGrip;
        public InputAction @RightGrip => m_Wrapper.m_Gameplay_RightGrip;
        public InputAction @ButtonA => m_Wrapper.m_Gameplay_ButtonA;
        public InputAction @ButtonB => m_Wrapper.m_Gameplay_ButtonB;
        public InputAction @ButtonX => m_Wrapper.m_Gameplay_ButtonX;
        public InputAction @ButtonY => m_Wrapper.m_Gameplay_ButtonY;
        public InputAction @OpenProgramming => m_Wrapper.m_Gameplay_OpenProgramming;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @PrimaryStick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryStick;
                @PrimaryStick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryStick;
                @PrimaryStick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryStick;
                @SecondaryStick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryStick;
                @SecondaryStick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryStick;
                @SecondaryStick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryStick;
                @LeftTrigger.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftTrigger;
                @RightTrigger.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightTrigger;
                @LeftGrip.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftGrip;
                @LeftGrip.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftGrip;
                @LeftGrip.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftGrip;
                @RightGrip.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightGrip;
                @RightGrip.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightGrip;
                @RightGrip.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightGrip;
                @ButtonA.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonA;
                @ButtonA.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonA;
                @ButtonA.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonA;
                @ButtonB.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonB;
                @ButtonB.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonB;
                @ButtonB.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonB;
                @ButtonX.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonX;
                @ButtonX.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonX;
                @ButtonX.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonX;
                @ButtonY.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonY;
                @ButtonY.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonY;
                @ButtonY.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButtonY;
                @OpenProgramming.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenProgramming;
                @OpenProgramming.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenProgramming;
                @OpenProgramming.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenProgramming;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryStick.started += instance.OnPrimaryStick;
                @PrimaryStick.performed += instance.OnPrimaryStick;
                @PrimaryStick.canceled += instance.OnPrimaryStick;
                @SecondaryStick.started += instance.OnSecondaryStick;
                @SecondaryStick.performed += instance.OnSecondaryStick;
                @SecondaryStick.canceled += instance.OnSecondaryStick;
                @LeftTrigger.started += instance.OnLeftTrigger;
                @LeftTrigger.performed += instance.OnLeftTrigger;
                @LeftTrigger.canceled += instance.OnLeftTrigger;
                @RightTrigger.started += instance.OnRightTrigger;
                @RightTrigger.performed += instance.OnRightTrigger;
                @RightTrigger.canceled += instance.OnRightTrigger;
                @LeftGrip.started += instance.OnLeftGrip;
                @LeftGrip.performed += instance.OnLeftGrip;
                @LeftGrip.canceled += instance.OnLeftGrip;
                @RightGrip.started += instance.OnRightGrip;
                @RightGrip.performed += instance.OnRightGrip;
                @RightGrip.canceled += instance.OnRightGrip;
                @ButtonA.started += instance.OnButtonA;
                @ButtonA.performed += instance.OnButtonA;
                @ButtonA.canceled += instance.OnButtonA;
                @ButtonB.started += instance.OnButtonB;
                @ButtonB.performed += instance.OnButtonB;
                @ButtonB.canceled += instance.OnButtonB;
                @ButtonX.started += instance.OnButtonX;
                @ButtonX.performed += instance.OnButtonX;
                @ButtonX.canceled += instance.OnButtonX;
                @ButtonY.started += instance.OnButtonY;
                @ButtonY.performed += instance.OnButtonY;
                @ButtonY.canceled += instance.OnButtonY;
                @OpenProgramming.started += instance.OnOpenProgramming;
                @OpenProgramming.performed += instance.OnOpenProgramming;
                @OpenProgramming.canceled += instance.OnOpenProgramming;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
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
    private int m_VRSchemeIndex = -1;
    public InputControlScheme VRScheme
    {
        get
        {
            if (m_VRSchemeIndex == -1) m_VRSchemeIndex = asset.FindControlSchemeIndex("VR");
            return asset.controlSchemes[m_VRSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnPrimaryStick(InputAction.CallbackContext context);
        void OnSecondaryStick(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
        void OnLeftGrip(InputAction.CallbackContext context);
        void OnRightGrip(InputAction.CallbackContext context);
        void OnButtonA(InputAction.CallbackContext context);
        void OnButtonB(InputAction.CallbackContext context);
        void OnButtonX(InputAction.CallbackContext context);
        void OnButtonY(InputAction.CallbackContext context);
        void OnOpenProgramming(InputAction.CallbackContext context);
    }
}
