using System.Collections.Generic;
using UnityEngine;

public class EnemySkillUpgrade : MonoBehaviour, IGetCompoable,IAfterInitable
{
    private GetCompoParent _parent;
    private SkillAdder _skillAdder;

    public ActGroupSO CanHaveActs;

    private List<ActSO> CanHaveActList => CanHaveActs.CanHaveSkillList;
    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;
    }

    public void AfterInit()
    {
        _skillAdder = _parent.GetCompo<SkillAdder>();
    }
    public void AddSkillAdderListAdd(ActSO act)
    {
       CanHaveActList.Add(act);
    }

    public void AddSkillAdderListAdd(List<ActSO> actList)
    {
        CanHaveActList.AddRange(actList);
    }

    public void AddSKillAdderRandom()
    {
        _skillAdder.AddAddList(CanHaveActList[Random.Range(0, CanHaveActList.Count)]);
    }

}
