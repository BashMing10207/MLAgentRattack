using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class StatInstance
{
    public StatSO Stat;
    protected float _value;

    //public float Value;

    public bool IsOverride;
    public float OVerrideValue;
    public List<StatModifierSO> Modifiers = new List<StatModifierSO>();

    public void SetBaseValue(float value)
    {
        _value = value;
    }

    protected virtual float GetModifierValue()
    {
        float a = 0;
        List<float> b = new List<float>();

        if (Modifiers.Count > 0)
        {
            foreach (var modifier in Modifiers)
            {
                switch (modifier.IsMultiply)
                {
                    case ModifierType.Multiply:
                        b.Add(modifier.ModifierValue);
                        break;

                    case ModifierType.MultiplyAdd:
                        a += modifier.ModifierValue;
                        break;

                    case ModifierType.Add:

                        break;
                }
            }
        }

        a += 1; //((1 + add)*multi) * baseStat
        if (Modifiers.Count > 0)
        {
            foreach (var c in b)
            {
                a *= c;
            }
        }

        return a;
    }
    public void TryAddModifier(StatModifierSO mod)
    {
        //foreach (var modifier in Modifiers)
        //{
        //    //if (modifier == mod)
        //    //{
        //    //    modifier.Second = Mathf.Min(modifier.Second+1,mod.MaxStack);
        //    //    return;
        //    //}
        //}
        Modifiers.Add(mod);
    }
    public void TryRemoveModifier(StatModifierSO mod)
    {
        //foreach (var modifier in Modifiers)
        //{
        //    //if (modifier == mod)
        //    //{
        //    //    modifier.Second = Mathf.Min(modifier.Second+1,mod.MaxStack);
        //    //    return;
        //    //}
        //}
        Modifiers.Remove(mod);
    }
    //public void TryAddTemponaryModifiler(StatModifierSO mod)
    //{
    //    //TryAddModifier(mod);
    //    TempModifilerAndRemain.Add(new SetablePair<StatModifierSO, int>(mod, mod.RemainingTurn));
    //}

    public void ModifierTurnLoss()
    {
        for (int i = Modifiers.Count; i > 0; i--)
        {
            if (Modifiers[i].RemainingTurn > 0)
                Modifiers[i].RemainingTurn--;
            if (Modifiers[i].RemainingTurn == 0)
                Modifiers.Remove(Modifiers[i]);
        }
    }
}

public class StatManager : MonoBehaviour,IGetCompoable
{
    [SerializeField]
    private List<StatInstance> _stats = new ();
    protected GetCompoParent _parent;

    //스텟은 어찌되었든 고정인데, 굳이 SO로 하여야 할까? -> 나무나 돌에 Dex달린 꼴은 못봐주겠노
    
    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;

        
    }

    public void Init()
    {
        foreach (StatInstance stat in _stats)
        {
            if (stat.IsOverride)
            {
                stat.SetBaseValue(stat.OVerrideValue);
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
        foreach (StatInstance stat in _stats)
        {
            stat.ModifierTurnLoss();
        }
    }

    public StatInstance GetStat(string StatName)
    {
        foreach (StatInstance stat in _stats)
        {
            if(stat.Stat.StatName == StatName) return stat;
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
