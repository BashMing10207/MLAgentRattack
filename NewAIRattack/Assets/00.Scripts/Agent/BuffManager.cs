using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour, IGetCompoable
{
    private GetCompoParent _parent;
    private StatManager _statManager;

    private List<BuffSO> _buffs;

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
        foreach (BuffSO buff in _buffs)
        {
            buff.TurnEffect(_parent);
        }
    }

    public void AddBuff(BuffSO buff)
    {
        _buffs.Add(buff);
        buff.Init(_parent);

        _statManager.AddStatMod(buff.StatModifier);
    }

    public void RemoveBuff(BuffSO buff)
    {
        _buffs.Remove(buff);

        _statManager.RemoveStatMod(buff.StatModifier);
    }

}
