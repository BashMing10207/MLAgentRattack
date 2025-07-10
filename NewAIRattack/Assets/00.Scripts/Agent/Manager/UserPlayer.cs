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
        //if ���� Ŭ���̾�Ʈ�� ��.
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

