using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BuffInstance
{
    public BuffSO BuffType;
    public int RemainingTurn;

    private BuffManager _buffManager;

    public BuffInstance(BuffSO buff, int remainingTurn,BuffManager buffmanager) : this()
    {
        BuffType = buff;
        RemainingTurn = remainingTurn;
        _buffManager = buffmanager;
    }

    public void TurnEffect(GetCompoParent entity)
    {
        BuffType.TurnEffect(entity);

        RemainingTurn--;

        if (RemainingTurn == 0) //0이하의 시간을 가지면 무한밍 ㅎㅎ
        {
            RemoveBuff();
        }
    }
    public void StatBuff(GetCompoParent entity)
    {
        _buffManager.AddBuff(BuffType);
    }

    public void RemoveBuff()
    {
        _buffManager.RemoveBuff(this);
    }

}

public class BuffManager : MonoBehaviour, IGetCompoable
{
    private GetCompoParent _parent;
    private StatManager _statManager;

    private List<BuffInstance> _buffs;

    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;

        _statManager = entity.GetCompo<StatManager>();
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
        foreach (BuffInstance buff in _buffs)
        {
            buff.BuffType.TurnEffect(_parent);
        }
    }

    public void AddBuff(BuffSO buff)
    {
        _buffs.Add(new BuffInstance(buff,buff.RemainingTurn,this));
        //buff.Init(_parent);

        _statManager.AddStatMod(buff.StatModifier);
    }

    public void RemoveBuff(BuffInstance buff)
    {
        _buffs.Remove(buff);

        //_statManager.RemoveStatMod(buff.StatModifier);
    }

}
