using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class UIParentActive : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _ui;
    public UnityEvent OnActive,OnDisAble;
    //private void Update()
    //{
    //    if(Keyboard.current.yKey.wasPressedThisFrame)
    //    {
    //        UIToggle();
    //    }
    //}

    public void UIToggle()
    {
        _ui.alpha = _ui.alpha == 1 ? 0 : 1;
        _ui.interactable = !_ui.interactable;
        _ui.blocksRaycasts = !_ui.blocksRaycasts;
        OnActive?.Invoke();
    }
    public void UIEnable(bool enable)
    {
        UIActive(enable);
        if(enable)
        OnActive?.Invoke();
        else OnDisAble?.Invoke();
    }

    public void UIActive(bool enable)
    {
        _ui.alpha = enable ? 1 : 0;
        _ui.interactable = enable;
        _ui.blocksRaycasts = enable;
    }
    public void UIDIsActive()
    {
        UIEnable(false);
    }
}
