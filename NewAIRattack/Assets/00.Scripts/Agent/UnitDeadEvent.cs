using UnityEngine;

public class UnitDeadEvent : MonoBehaviour, IAgentDieEvent,IGetCompoable
{
    private Unit _parent;

    public void Initialize(GetCompoParent entity)
    {
       _parent = entity as Unit;
    }

    public void OnDead()
    {
        _parent.MasterController.GetCompo<AgentManager>(true).UnitDie(_parent);
    }
}
