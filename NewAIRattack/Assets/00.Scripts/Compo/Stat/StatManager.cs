using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class StatOverride
{
    public StatSO Stat;
    public bool IsOverride;
    public float OVerrideValue;
}

public class StatManager : MonoBehaviour,IGetCompoable
{
    [SerializeField]
    private List<StatOverride> _stats = new ();
    private List<SetablePair<StatSO,int>> _modifierDeleteList = new List<SetablePair<StatSO, int>>();
    protected GetCompoParent _parent;

    //스텟은 어찌되었든 고정인데, 굳이 SO로 하여야 할까?
    
    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;

        
    }

    public void Init()
    {
        foreach (StatOverride stat in _stats)
        {
            if (stat.IsOverride)
            {
                stat.Stat.SetBaseValue(stat.OVerrideValue);
            }
        }
    }

    public void Start()
    {
        GameManager.Instance.OnTurnEnd += RemoveTempStat;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnTurnEnd -= RemoveTempStat;
    }

    private void RemoveTempStat()
    {
        //_modifierDeleteList.
        foreach (StatOverride stat in _stats)
        {
            stat.Stat.ModifierTurnLoss();
        }
    }

    public StatSO GetStat(string StatName)
    {
        foreach (StatOverride stat in _stats)
        {
            if(stat.Stat.StatName == StatName) return stat.Stat;
        }
        return null;
    }

    public virtual void AddStatMod(StatModifierSO statMod)
    {
        GetStat(statMod.TargetStat.StatName)?.TryAddModifier(statMod);
    }
    public virtual void RemoveStatMod(StatModifierSO statMod)
    {
        GetStat(statMod.TargetStat.StatName)?.TryAddModifier(statMod);
    }
}
