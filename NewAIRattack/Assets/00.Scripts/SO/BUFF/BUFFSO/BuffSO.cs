using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffSO", menuName = "SO/Buff")]
[Serializable]
public class BuffSO : ScriptableObject
{
    public Texture2D Icon;

    public string Name = "";

    public int MaxStack = 5;

    public int RemainingTurn = 2;

    public StatModifierSO StatModifier;

    public BuffManager TargetBuffManager;

    private GetCompoParent _parent; 

    public virtual void Init(GetCompoParent entity)
    {
        _parent = entity;
        TargetBuffManager = entity.GetCompo<BuffManager>();
    }

    public virtual void StatBuff()
    {
        TargetBuffManager.AddBuff(this);
    }

    public virtual void StartEffect()
    {
        StatBuff();
    }

    public virtual void TurnEffect(GetCompoParent entity)
    {

        RemainingTurn--;
        
        if(RemainingTurn ==0) //0������ �ð��� ������ ���ѹ� ����
        {
            RemoveBuff();
        }
    }

    public virtual void RemoveBuff()
    {
        //when Buff ENd
        TargetBuffManager.RemoveBuff(this);
    }

    public virtual object Clone()
    {
        return Instantiate(this); //(�Ƹ���)SO�� ���� �� ȣ���Ͽ� ���� ���� �����ϴ� ����. https://learn.microsoft.com/en-us/dotnet/api/system.icloneable?view=net-9.0 <- (dd)
    }

}
