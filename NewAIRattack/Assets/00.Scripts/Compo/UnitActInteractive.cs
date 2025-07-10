using UnityEngine;
using UnityEngine.Events;

public enum EActInteractiveType
{
    None,
    Drag,
    Click,
    ObjectClick
}
public class UnitActInteractive : MonoBehaviour, IGetCompoable, IAfterInitable
{
    private GetCompoParent _parent;

    private ActCommander _commander;

    public EActInteractiveType CurrentInteractiveType { get; private set; }

    public bool IsSelected { get; private set; }

    [SerializeField]
    private float _holdMulti = 25;
    public Vector2 PostMousePos { get; private set; } = new Vector2(0, 0);
    public bool IsHolding = false;

    public UnityEvent StartHold;
    public UnityEvent EndHold;
    public UnityEvent ChangeSelectUnit;

    protected AimLineRenderer _aimLineRenderer;
    private PlayerInputSO _playerInput;
    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;
    }
    public void AfterInit()
    {
        _commander = _parent.GetComponent<ActCommander>();
        _aimLineRenderer = _parent.GetCompo<AimLineRenderer>();
    }

    private void Start()
    {
        Init();
    }

    protected void Init()
    {
        _playerInput = GameManager.Instance.PlayerInputSO;

        _playerInput.OnClickEnter += HoldStart;
        _playerInput.OnClickExit += OnClickEnd;
        _playerInput.OnMouseScroll += Updown;
        _playerInput.DisSelectAct += HoldCancle;

        CurrentInteractiveType = EActInteractiveType.None;
        IsSelected = false;
    }

    public void SelectInteractiveType(EActInteractiveType interactivetype)
    {
        SetIsSelected(true);

        switch (interactivetype)
        {
            case EActInteractiveType.None:

                break;
            case EActInteractiveType.Drag:

                break;
            case EActInteractiveType.Click:

                break;
            case EActInteractiveType.ObjectClick:
                Debug.LogError("This is not Complete. Fix Here!");
                break;
            default:

                break;
        }
    }

    protected void RunAction(Vector3 dir)
    {
        if (gameObject.activeInHierarchy)
        {
            //if(GameManager.Instance.IsPlayerturn)
            Vector3 rot = _parent.GetCompo<CameraManager>().MainCamera1.transform.eulerAngles;
            dir = Quaternion.Euler(0, rot.y, 0) * dir;

            
        }
    }


    private void OnClickEnd()
    {
        switch(CurrentInteractiveType)
        {
            case EActInteractiveType.None:

                break;
            case EActInteractiveType.Drag:
                HoldEnd();
                break;
            case EActInteractiveType.Click:
                ClickPoint();
                break;
            case EActInteractiveType.ObjectClick:
                ClickObject();
                break;
            default:
                Debug.LogError("This is not Complete. Fix Here!");
                break;

        }
    }

    public void SetIsSelected(bool val)
    {
        IsSelected = val;
    }

    void Update()
    {
        if (IsHolding && IsSelected)
        {
            _aimLineRenderer.LineRender();
        }
        else
        {
            _aimLineRenderer.DisableLinRender();
        }
    }

#region Drag
    private void HoldStart()
    {
        //if (!_parent.GetCompo<PlayerActions>().IsOnPointer)
        if (IsSelected)
        {
            PostMousePos = _playerInput.MousePos;
            IsHolding = true;
            //Upward = 0;
            StartHold?.Invoke();
        }
    }

    private void Updown(float axis)
    {
        //Upward += axis * Time.deltaTime * 5;
    }

    private void HoldEnd()
    {

        if (IsHolding)
        {
            Vector3 dir = BashUtils.V2ToV3(PostMousePos - _playerInput.MousePos) / Screen.width * _holdMulti;
            _commander.TrySkill((dir + new Vector3(0, 0/*Upward*/, 0)).normalized * dir.magnitude);
            SetIsSelected(false);
        }
        IsHolding = false;

        EndHold?.Invoke();
    }

    private void HoldCancle()
    {
        IsHolding = false;
        SetIsSelected(false);
        EndHold?.Invoke();
    }
    #endregion
#region Click
    private void ClickPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            _commander.TrySkill(hitInfo.point);
        }
    }
    private void ClickObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if(hitInfo.transform.gameObject.CompareTag("Interactive"))
            {
                hitInfo.transform.gameObject.GetComponent<IClickable>().GetInteractive();

                Debug.LogError("This is not Complete. Fix Here!");
            }
        }
    }

#endregion
}
