using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillAndCool
{
    public ActSO First;
    public int Second;

    public SkillAndCool( ActSO first,int second )
    {
        this.First = first;
        this.Second = second;
    }
}

public class SkillAdder : MonoBehaviour, IGetCompoable
{
    private GetCompoParent _playerManager;

    //public List<SetablePair<ActSO, int>> AddSkillList = new(); //직렬화가 안되서 디버그 하기 불편한...
    public List<SkillAndCool> AddSkillList = new();

    [SerializeField]
    private ActGroupSO _canHaveSkill;

    [SerializeField] private int _maxIndex = 25;

    private void Start()
    {
        GameManager.Instance.OnTwoTurnEndEvent += AddSkill;

        for(int i = 0; i < AddSkillList.Count; i++)
        {
            if( AddSkillList[i].First == null )
            {
                SetAddList(_canHaveSkill.CanHaveSkillList[UnityEngine.Random.Range(0,_canHaveSkill.CanHaveSkillList.Count)], i);
            }
        }
    }

    public void Initialize(GetCompoParent entity)
    {
        _playerManager= entity;
    }

    public void AddAddList(ActSO act)
    {
        if(act.ActTypeEnum == ActType.Passive)
        {
            act.RunAct(Vector3.up,_playerManager);
        }
        AddSkillList.Add(new (act,act.SKillCoollDown));
    }

    public void SetAddList(ActSO act,int index)
    {
        if (_maxIndex < AddSkillList.Count)
            RemoveAddList(AddSkillList[0].First);

            AddSkillList[index] =(new(act, act.SKillCoollDown));
    }

    public void RemoveAddList(ActSO act)
    {
        AddSkillList.Remove(new(act, act.SKillCoollDown));
    }

    public void AddSkill()
    {
        //_playerManager.GetCompo<ItemManager>(true).Items.AddRange(AddSkillList);
       
        for(int i = 0; i < AddSkillList.Count; i++)
        {
            AddSkillList[i].Second--;
            if (AddSkillList[i].Second <= 0)
            {
                _playerManager.GetCompo<ItemManager>(true).Items.Add(AddSkillList[i].First);
                AddSkillList[i].Second = AddSkillList[i].First.SKillCoollDown;
            }
        }
    }
}
