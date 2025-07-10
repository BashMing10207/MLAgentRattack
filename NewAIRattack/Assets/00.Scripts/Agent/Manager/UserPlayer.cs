using UnityEngine.Events;
using UnityEngine.InputSystem;

public class UserPlayer : Player
{
    //public PlayerInputSO PlayerInput;
    protected override void Awake()
    {
        base.Awake();

    }

    protected override void Start()
    {
        base.Start();
        //if 내가 클라이언트일 때.
        GameManager.Instance.CurrentClientPlayerManagerCompo = this;
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameManager.Instance.OnTurnEnd();

        }
    }
}

