using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Unit : Agent
{

    public bool IsSelected = false;
    [SerializeField] private List<GameObject> _isSelectedObj, _isDisabledObj = new();
    public Transform ViewPivot;
    public Transform WeaponTrm;
    public GetCompoParent MasterController;

    public UnitController Controller;

    public StatManager UnitStat; //��� ���ֿ��� �����ϸ� ĳ���ϴ� ���� ����ȭ�� ������ �ȴٰ� �Ǵ��Ͽ���.

    protected List<IAgentDieEvent> AgentDieEventList = new();

    public UnityEvent OnGetTurn, OnReturnTurn;

    protected override void Awake()
    {
#if UNITY_EDITOR
        if (gameObject.GetComponent<UnitController>() == null)
            Debug.LogWarning("��Ʈ�ѷ��� ���ݾ�!!");
#endif

        base.Awake();
        AgentDieEventList.AddRange(GetComponentsInChildren<IAgentDieEvent>(true));
        UnitStat = GetComponentInChildren<StatManager>(true);
    }

    public void Init(GetCompoParent masterController)
    {
        MasterController = masterController;
    }

    public void GetTurn()
    {
        OnGetTurn?.Invoke();
        SelectVisual(true);

    }
    public void ReturnTurn()
    {
        OnReturnTurn?.Invoke();
        SelectVisual(false);

    }

    public void SelectVisual(bool enable)
    {
        IsSelected = enable;
        if(_isSelectedObj != null)
            foreach(var obj in _isSelectedObj)
                obj.SetActive(enable);
        if(_isDisabledObj != null)
            foreach(var obj in _isDisabledObj)
                obj.SetActive(!enable);
    }

    public void UnitDie()
    {
        GameManager.Instance.RemoveUnit(this);
        while(AgentDieEventList.Count > 0) 
        {
            AgentDieEventList[0].OnDead();
            AgentDieEventList.RemoveAt(0);
        }
    }
}

