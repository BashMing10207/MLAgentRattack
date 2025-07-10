using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAgentManager : AgentManager,IGetCompoable
{
    //private

    //[SerializeField]
    //private float _holdMulti = 25;//이건 나중에 인풋같은 거로 뺼 것.

    public Vector2 PostMousePos { get; private set; } = new Vector2(0, 0);

    public bool IsHolding = false;

    [SerializeField]
    private ActSO _defaultAct;

    //public UnityEvent StartHold;
    //public UnityEvent EndHold;
    public UnityEvent ChangeSelectUnit;

    private PlayerInputSO _playerInput;
    public float Upward { get; private set; } = 0;

    public bool IsSelected = false;

    public Action<bool> OnSelectAct;

    public override void Initialize(GetCompoParent entity)
    {
        base.Initialize(entity);

    }


    protected override void Start()
    {
        base.Start();
        Init();
        //MultiGameManager.Instance.PlayerManagerCompo.Add(this);
    }

    protected void Init()
    {
        _playerInput = GameManager.Instance.PlayerInputSO;

        _playerInput.UnitSwapEvent += SwapNextUnit;
        //_playerInput.OnClickEnter += HoldStart;
        //_playerInput.OnClickExit += HoldEnd;
        //_playerInput.OnMouseScroll += Updown;
        //_playerInput.DisSelectAct += HoldCancle;

        foreach (Unit item in Units)
            item.Init(_parent);

        SwapUnit(0);
    }

    public void SetActSelected(bool selected)
    {
        IsSelected = selected;
        OnSelectAct?.Invoke(selected);
    }

    private void SwapNextUnit(int idx)
    {
        SwapUnit(Mathf.Abs(SelectedUnitIdx + idx) % Units.Count);
    }
    protected override void SwapUnit(int idx)
    {
        base.SwapUnit(idx);

        ChangeSelectUnit?.Invoke();
    }

    //private void HoldStart()
    //{
    //    //if (!_parent.GetCompo<PlayerActions>().IsOnPointer)
    //    if(IsSelected)
    //    {
    //        PostMousePos = _playerInput.MousePos;
    //        IsHolding = true;
    //        Upward = 0;
    //        StartHold?.Invoke();
    //    }
    //}

    //private void Updown(float axis)
    //{
    //    //Upward += axis * Time.deltaTime * 5;
    //}

    //private void HoldEnd()
    //{

    //    if (IsHolding)
    //    {
    //        Vector3 dir = BashUtils.V2ToV3(PostMousePos - _playerInput.MousePos) / Screen.width * _holdMulti;
    //        GetAction((dir + new Vector3(0, -Upward, 0)).normalized * dir.magnitude);
    //        SetActSelected(false);
    //    }
    //    IsHolding = false;

    //    EndHold?.Invoke();
    //}

    //private void HoldCancle()
    //{
    //    IsHolding = false;
    //    SetActSelected(false);
    //    EndHold?.Invoke();
    //}

    protected override void RunAction(Vector3 dir)
    {
        if (gameObject.activeInHierarchy)
        {
            //if(GameManager.Instance.IsPlayerturn)
            Vector3 rot = _parent.GetCompo<CameraManager>().MainCamera1.transform.eulerAngles;
            dir = Quaternion.Euler(0, rot.y, 0) * dir;

            base.RunAction(dir);
        }
    }

    public override void UnitDie(Unit unit)
    {
        base.UnitDie(unit);
    }
}
