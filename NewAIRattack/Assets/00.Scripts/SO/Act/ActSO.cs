using System;
using UnityEngine;

public enum ActType
    {
        Projectile,
        Impact,
        Melee,
        Move,
        Buff,
        Passive
    }
//[CreateAssetMenu(fileName="SO/Act")]
[Serializable]
public abstract class ActSO : ScriptableObject
{

    public float MinPower = 1f, MaxPower = 10f;

    public int CostPoints = 1;

    public string ActName = "";
    [Multiline]
    public string Description = "";

    public Sprite Icon;

    public string AnimParamName;
    public int HashValue;

    public bool IsCanActable = true;

    public ActType ActTypeEnum;
    public float MaxDistance = 10f;

    public float StatModValue = 0.1f;

    public int SKillCoollDown = 1;

    public int SkillNeedPower = 1;

    public int CurrentSkillCoolDown = 0;
    public int CurrentDurability = 0;

    public bool Destroyable = false;
    public bool IsCoolDown = false;

    protected IInventoryable _owningInventory;

    public EActInteractiveType InteractiveType;

    protected GetCompoParent _parent;

    [SerializeField]
    protected StatSO _affectStat;

    public virtual object Clone()
    {
        return Instantiate(this); //(아마도)SO를 만들 때 호출하여 기존 값을 복제하는 역할. https://learn.microsoft.com/en-us/dotnet/api/system.icloneable?view=net-9.0 <- (dd)
    }

    public virtual void Init(GetCompoParent entity)
    {
        _parent = entity;
    }

    public virtual void Init(IInventoryable inventory)
    {
        _owningInventory = inventory;
    }

    public void EnableActExable(bool enable)
    {
        IsCanActable = enable;
    }

    public void ToggleActExable()
    {
        IsCanActable = !IsCanActable;
    }

    private void OnValidate()
    {
        HashValue = Animator.StringToHash(AnimParamName);
    }

    public abstract void RunAct(Vector3 dir, GetCompoParent agent);

    public virtual void EndAct(GetCompoParent agent)
    {
        CurrentSkillCoolDown = SKillCoollDown;
        CurrentDurability--;
        if(CurrentDurability <=0)
        {
            RemoveInventory();
            DestroyAct();
        }
    }

    public virtual void RemoveInventory()
    {
        _owningInventory.RemoveSkillorItem(this);
    }
    public virtual void DestroyAct()
    {
        Debug.Log("뿌라지는 것을 구현하십시오!");
    }

    protected float PlayerANDAgentStat(GetCompoParent agent)
    {
        if (_affectStat == null) return 1;
        StatSO stat = agent.GetCompo<StatManager>().GetStat(_affectStat.StatName);
        if (stat == null) return 1;

        //if(agent.GetType() == typeof(Unit))
        //{
        //    return  1+(stat.Value * (agent as Unit).MasterController.GetCompo<StatManager>().GetStat(_affectStat.StatName).Value)*StatModValue;
        //}

        return stat.Value;
    }
}
