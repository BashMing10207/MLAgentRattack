
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : GetableCoponentBase, IInventoryable
{

    public List<ActSO> Items = new();

    public List<ActSO> Skills = new();

    public int MaxItemIdx = 5;
    public int MaxSkillIdx = 5;

    public override void Initialize(GetCompoParent entity)
    {
        Parent = entity;
    }


    public void TurnEvent()
    {

    }



    public bool AddItem(ActSO act)
    {
        if (act == null)
        {
            Debug.LogAssertion("���濡 �� �ִ°ų� �̱��");
            return false;
        }
        if (MaxItemIdx < Items.Count + 1)
            return false;

        Items.Add(act);

        return true;
    }

    public bool AddSkill(ActSO act)
    {
        if (act == null)
        {
            Debug.LogAssertion(" �̱��");
            return false;
        }
        if (MaxItemIdx < Skills.Count + 1)
            return false;

        Skills.Add(act);


        return true;
    }

    public void RemoveSkill(ActSO act)
    {
        if (act == null)
        {
            Debug.LogAssertion("null�� �����ϱ� ���� ��");
            return;
        }
        if(Skills.Contains(act))
        Skills.Remove(act);
    }
    public void RemoveItem(ActSO act)
    {
        if (act == null)
        {
            Debug.LogAssertion("null�� �����ϱ� ���� ��");
            return;
        }
        if (Skills.Contains(act))
            Items.Remove(act);
    }
    public void Start()
    {
        
    }

    public void OnDestroy()
    {

    }

    public void RemoveSkillorItem(ActSO act)
    {
        RemoveItem(act);
        RemoveSkill(act);
    }
}
