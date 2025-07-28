using UnityEngine;

public abstract class UnitController : GetableCoponentBase, IAfterInitable
{
    protected Unit _parentUnitCompo;
    protected ItemManager _itemManager;
    protected AgentActCommander _agentActCommander;

    public void AfterInit()
    {
        _parentUnitCompo = (Unit)Parent;
        _parentUnitCompo.OnGetTurn.AddListener(GetTurn);
        _parentUnitCompo.OnReturnTurn.AddListener(ReturnTurn);
        _itemManager = Parent.GetComponent<ItemManager>();
        _agentActCommander = Parent.GetComponent<AgentActCommander>();
    }
    public abstract void GetTurn();
    public abstract void ReturnTurn();
}
