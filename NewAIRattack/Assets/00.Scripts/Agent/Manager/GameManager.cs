using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GetCompoParent //Manager<GameManager>
{
    public static GameManager Instance;

    public Action OnTurnEnd;

    private bool _isPlayerturn =true;
    public bool IsPlayerturn => _isPlayerturn;

    #region GamePlayManager
    //�����������̸� GamePlayManage�� ����� ���� ������, �������� GetCompo Ȥ�� ĳ���� �޸𸮿� CPU�ڿ��� �� �����Ͽ� �׷��� ����ȭ ���� ���Ŀ� �� ����.

    public List<GetCompoParent> PlayerManagerCompos = new List<GetCompoParent>();
    //public EnemyManager EnemyManagerCompo;
    //public GetCompoParent PlayerManagerCompo => PlayerManagerCompos[_isPlayerturn ? 0:1];
    public GetCompoParent CurrentClientPlayerManagerCompo; // CurrentPlayer <= you

    public List<Unit> Units = new List<Unit>(); //���ָ���Ʈ. ��Ʈ�ѷ��� �� �������� �Űܰ��ԵǾ���.

    public int CurrentActiveUnitIndex = 0;
    public Unit CurrentActiveUnit()
    {
        if (Units[CurrentActiveUnitIndex])
            return Units[CurrentActiveUnitIndex];
        else
            CurrentActiveUnitIndex%=Units.Count;
        if (Units[CurrentActiveUnitIndex])
            return Units[CurrentActiveUnitIndex];

        Debug.LogError("WTF ������ ����");
        return null;
    }

    public Action OnTwoTurnEndEvent,OnTurnEndEvent;


    public PlayerInputSO PlayerInputSO;

    protected Queue<Unit>[] _tempUnits = new Queue<Unit>[10];

    protected override void Awake()
    {
        //if(Instance != null)
        //    Destroy(Instance);

        Instance = this;
        base.Awake();
        OnTurnEnd += TurnEnd;
    }

    public void AddUnit(Unit unit)
    {
        Units.Add(unit);
    }
    public void RemoveUnit(Unit unit)
    {
        Units.Remove(unit);
    }
    public void SortUnitByStat(string StatName)
    {
        int tempindex = 0;

        //List<Unit> list2 = Units.ToList();
        for(int i = 0; i<10; i++)
        {
            _tempUnits[i].Clear();
        }
        //new() �ϴ� �ͺ��ٴ� Clear�� �����ٰ� �ϱ⿡ �̷��� �Ͽ���

        for (int i = 1; i < 1000; i *= 10) //���������!
        {
            for (int j = 0; j < Units.Count; j++)
            {
                _tempUnits[(int)((Units[j].UnitStat.GetStat(StatName).Value) / i % 10)].Enqueue(Units[j]);
            }
            for(int j = 0;j < 10;j++)
            {
                while(_tempUnits[j].Count >0)
                if(_tempUnits[j].TryDequeue(out Unit unit))
                {
                    Units[tempindex] = unit;
                    tempindex++;
                }

            }
        }
    } //�������

    public void AddPlayer(Player player)
    {
        PlayerManagerCompos.Add(player);
    }



    #endregion
    #region TurnManager

    [ContextMenu("TurnChange")]
    private void TurnEnd()
    {
        //CurrentClientPlayerManagerCompo.gameObject.SetActive(false);
        //_isPlayerturn = !_isPlayerturn;//�ϳѱ��
        //CurrentClientPlayerManagerCompo.gameObject.SetActive(true);
        CurrentActiveUnit().ReturnTurn();

        CurrentActiveUnitIndex = (CurrentActiveUnitIndex+1) % Units.Count;
       // CurrentActiveUnit().GetCompo<UnitController>(true).GetTurn();

       CurrentActiveUnit().GetTurn();

        OnTurnEndEvent?.Invoke();

        if(_isPlayerturn)
            OnTwoTurnEndEvent?.Invoke();
        
    }
    #endregion
    //private void Update()
    //{
    //    if (Keyboard.current.rKey.wasPressedThisFrame)
    //    {
    //        TurnEnd();
    //    }
    //}
}
