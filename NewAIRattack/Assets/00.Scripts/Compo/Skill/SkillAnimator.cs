using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SkillAnimator : MonoBehaviour,IGetCompoable,IAfterInitable
{
    [SerializeField]
    private Animator _anim;
    private GetCompoParent _agent;

    public UnityAction RealSkillAction; // c# is very suck... so Method pointer is not useable TT
    public UnityAction EndSkillAction;
    protected Transform _targetTrm;
    public void Initialize(GetCompoParent entity)
    {
        _agent = entity;
        
    }

    public void AfterInit()
    {
        //_agent.GetCompo<AgentManager>(true).ActionExcutor += SetAnimPowerValue;
    }

    private void Update()
    {
        if(_targetTrm == null)
        {
            Debug.Log("Notarget");
            return;
        }    

        SetPos(_targetTrm);
    }

    public void SetPos(Transform trm)
    {
        transform.SetPositionAndRotation(trm.position, trm.rotation);
    }
    public void SetAnim(int hash)
    {
        _anim.SetTrigger(hash);
    }
    public void SetAnim(string str)
    {
        _anim.SetTrigger(str);
    }

    public void AttackAnim()
    {
        _anim.SetTrigger("Attack");
    }

    private void SetAnimPowerValue(Vector3 dir)
    {
        _anim.SetFloat("Value",dir.magnitude);
    }

    public void RealSkillRun()
    {
        RealSkillAction.Invoke();
    }
    public void EndSkill()
    {
        EndSkillAction.Invoke();
        RealSkillAction=null;
        EndSkillAction=null;
    }
    public void SetTargetTrm(Transform trm)
    {
        _targetTrm = trm;
    }
}
