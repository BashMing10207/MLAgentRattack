using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentManager : MonoBehaviour, IGetCompoable//GetCompoParent // : Manager<AgentManager>
{
    public List<Unit> Units = new List<Unit>();

    public int SelectedUnitIdx = 0;

    public event Action<Vector3> ActionExcutor;

    protected GetCompoParent _parent;

    public Action<Unit> OnSwapUnit;

    public UnityEvent OnUnitDieEvent;
    [SerializeField]
    private Unit _unitprefab;

    public virtual void Initialize(GetCompoParent entity)
    {
        _parent = entity;
        //print(entity.gameObject.name);
        foreach (Unit unit in Units)
        {
            unit.Init(_parent);

        }
    }

    protected virtual void Start()
    {
        //Units.ForEach(unit => unit.Init(_parent));

    }
    public Unit SelectedUnit() => Units[SelectedUnitIdx];
    protected virtual void RunAction(Vector3 dir)
    {
        ActionExcutor?.Invoke(dir);
    }

    public void CreateStone(Vector3 pos)
    {
        AddStone(Instantiate(_unitprefab, pos, Quaternion.identity));
    }

    public void AddStone(Unit unit)
    {
        Units.Add(unit);
        unit.Init(_parent);
    }

    protected virtual void SwapUnit(int idx)
    {
        if(SelectedUnitIdx < Units.Count)
        Units[SelectedUnitIdx]?.SelectVisual(false);
        if (Units.Count < idx)
        {
            idx = 0;
        }
        if (Units.Count == 0)
        {
            _parent.GetCompo<GameOverEvent>().GameOver();
            return;
        }

        SelectedUnitIdx = idx;
        Units[idx].SelectVisual(true);
        OnSwapUnit?.Invoke(Units[idx]);
    }

    public virtual void UnitDie(Unit unit)
    {

        Unit slected = SelectedUnit();

        Units.Remove(unit);

        if (slected != unit)
        {
            SwapUnit(Units.IndexOf(slected));
        }
        else if(Units.Count == 0)
        {
            _parent.GetCompo<GameOverEvent>().GameOver();
            Destroy(unit.gameObject);

            OnUnitDieEvent?.Invoke();
            return;
        }
        else
        {

            SwapUnit(0);
        }


        Destroy(unit.gameObject);

        OnUnitDieEvent?.Invoke();

        

    }

}


