using System;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/Player/InputSO")]
public class PlayerInputSO : ScriptableObject, Input2.IPlayerActions, Input2.IUIActions
{
    public event Action JumpEvent;
    public event Action AttackEvent;
    public event Action OpenMenuKeyEvent;
    public event Action TurnEndEvent;
    public Action<int> UnitSwapEvent;
    public event Action OnClickEnter;
    public event Action OnClickExit;
    public event Action OnClickEnter2;
    public event Action OnClickExit2;
    public event Action<float> OnMouseScroll;
    public event Action<Vector2> Arrow;
    public event Action DisSelectAct;
    public bool IsPressing = false;
    public bool IsPressing2 = false;
    public Vector2 InputDirection { get; private set; }

    public Vector2 MousePos { get; private set; }
    private Input2 _controls;
    public Vector2 MouseDelta { get; private set; }

    private void OnEnable()
    {
       ActiveInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    public void ActiveInput()
    {
        if (_controls == null)
        {
            _controls = new Input2();
            _controls.Player.SetCallbacks(this);
            _controls.UI.SetCallbacks(this);
        }
        _controls.Player.Enable();
        _controls.UI.Enable();
    }
    public void DisActivePlayerInput()
    {
        _controls.Player.Disable();
    }

    public void DisableInput()
    {
        _controls.Player.Disable();
        _controls.UI.Disable();
    }

    public void SetPlayerInput(bool isEnable)
    {
        if (isEnable)
            _controls.Player.Enable();
        else
            _controls.Player.Disable();
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        if (context.performed)
            TurnEndEvent?.Invoke();
    }

    public void OnMousePos(InputAction.CallbackContext context)
    {
        MousePos = context.ReadValue<Vector2>();
    }

    public void OnMouseButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnClickEnter?.Invoke();
            IsPressing = true;
        }
        if (context.canceled)
        {
            OnClickExit?.Invoke();
            IsPressing=false;
        }

    }
    public void OnMouseButton2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnClickEnter2?.Invoke();
            IsPressing2 = true;
        }
        if (context.canceled)
        {
            OnClickExit2?.Invoke();
            IsPressing2 = false;
        }
    }

    public void OnSwap(InputAction.CallbackContext context)
    {
        if (context.performed)
            UnitSwapEvent?.Invoke(1);
        //UnitSwapEvent?.Invoke(context.ReadValue<int>());
    }

    public void OnScrol(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnMouseScroll?.Invoke(context.ReadValue<float>());
        }
    }

    public void OnEsc(InputAction.CallbackContext context)
    {
        if (context.performed)
            OpenMenuKeyEvent?.Invoke();
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    void Input2.IUIActions.OnClick(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnOpenMenu(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
    }

    public void OnArrow(InputAction.CallbackContext context)
    {
        Arrow?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnDisSelect(InputAction.CallbackContext context)
    {
        DisSelectAct?.Invoke();
    }
}
