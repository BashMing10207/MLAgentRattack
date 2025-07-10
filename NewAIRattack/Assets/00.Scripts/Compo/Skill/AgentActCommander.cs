using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentActCommander : MonoBehaviour, IGetCompoable
{
    private Agent _agent;
    //public List<ActSO> OwnActs = new List<ActSO>();
    public Transform WeaponTrm;

    private StatManager _statManager;

    public int ActPoint = 0;

    public Action ActFail;

    public ActSO CurrentAct;

    public UnityEvent OnActChangeEvent, OnActRunEvent;

    protected SkillAnimator _skillAnimator;

    protected Vector3 _tempDir = Vector3.zero;

    public void Initialize(GetCompoParent entity)
    {
        _agent = entity as Agent;
        _statManager = entity.GetCompo<StatManager>();
    }

    public void ExecuteAct(Vector3 dir)
    {
        _tempDir = dir;
        if(CurrentAct.IsCanActable)
        if (ActPoint - CurrentAct.SkillNeedPower >=0)
        {
            //ActPoint -= CurrentAct.SkillNeedPower;
            ActPoint = Mathf.Clamp(ActPoint - CurrentAct.CostPoints, 0, 999);

            //float power = Mathf.Clamp(dir.magnitude + CurrentAct.MinPower, 0f, Mathf.Min(ActPoint, CurrentAct.MaxPower));

            //CurrentAct.RunAct(dir,_agent);

            OnActRunEvent?.Invoke();
        }
    }



    public void RealRunAct()
    {
        CurrentAct.RunAct(_tempDir, _agent);
    }

    public void RealEndAct()
    {
        Debug.LogAssertion("Fix!! This IS Not Developped.. TT E TT");
        
        CurrentAct.EndAct(_agent);
        
        //커런트 액트에 끝 호출하고 뭐시기.. (다 만들어야디)
    }

    public void SetCurrentAct(ActSO act)
    {
        _skillAnimator = GameManager.Instance.GetComponent<SkillAnimator>();

#if UNITY_EDITOR
        if (_skillAnimator == null)
            Debug.LogAssertion("Fuck!! it has no SkillAnimator");
#endif

        if (CurrentAct != null)
        {
            _skillAnimator.RealSkillAction = null;
            _skillAnimator.EndSkillAction = null;
        }

            CurrentAct = act;

        if(CurrentAct == null)
        {
            _skillAnimator.SetAnim("None");
            return;
        }

        
        _skillAnimator.SetTargetTrm(WeaponTrm);
        _skillAnimator.RealSkillAction += RealRunAct;
        _skillAnimator.EndSkillAction += RealEndAct;
        _skillAnimator.SetAnim(CurrentAct.HashValue);
    }




}
