using UnityEngine;

public class ActCommander : MonoBehaviour,IGetCompoable,IAfterInitable
{
    private GetCompoParent _manager;
    private AgentManager _agentManager;

    //public float ActionPoint = 10f;
    public int ActionPoint = 3;


    public void Initialize(GetCompoParent entity)
    {
        _manager = entity;
       
    }

    public void AfterInit()
    {
        _manager.GetCompo<AgentManager>(true).ActionExcutor += TrySkill;
        _agentManager = _manager.GetCompo<AgentManager>(true);
    }

    public void TrySkill(Vector3 dir)
    {
        if(ActionPoint <=0)
        {

        }

        //ActionPoint = Mathf.Clamp(ActionPoint - act.CostPoints,0,999);

        //float power = Mathf.Clamp(dir.magnitude + act.MinPower, 0f, Mathf.Min(ActionPoint, act.MaxPower));

        // if (power < act.MinCost)
        //{
        //    ActFail?.Invoke();
        //    return;
        //}
        //_manager.GetCompo<SkillAnimator>().SetAnim(act.HashValue);
        //_manager.GetCompo<SkillAnimator>().SetAnim("Attack");
        //_manager.GetCompo<PlayerActions>().AttackAnim();
       if (_agentManager.Units.Count == 0) 
        {
            _manager.GetCompo<GameOverEvent>().GameOver();
            return;
        }
        else if (_agentManager.Units.Count >= _agentManager.SelectedUnitIdx)
        {


            _agentManager.SelectedUnit().GetCompo<AgentActCommander>().ExecuteAct(dir);
        }
       else
        {
            _agentManager.SelectedUnitIdx = Mathf.Max(0,_agentManager.Units.Count);
        }

        //ActionPoint -= power;
        if (ActionPoint > 0)
        {

        }
    }

    //public void TrySkill(Vector3 dir)
    //{
    //    //ActSO act = CurrentAct;
    //    TrySkill(dir, act);
    //}

    //public void SetAct(ActSO act)
    //{
    //    //CurrentAct = act;

    //    //OnActChangeEvent?.Invoke();
    //}


}
