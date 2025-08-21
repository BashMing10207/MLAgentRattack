using UnityEngine;

public abstract class UnitController : GetableCoponentBase, IAfterInitable
{
    protected Unit _parentUnitCompo;
    protected ItemManager _itemManager;
    protected AgentActCommander _agentActCommander;

    public override void Initialize(GetCompoParent entity)
    {
        base.Initialize(entity);
        _parentUnitCompo = entity as Unit;
        _parentUnitCompo.Controller = this;
    }
    public void AfterInit()
    {
        //_parentUnitCompo = (Unit)Parent;
        _parentUnitCompo.OnGetTurn.AddListener(GetTurn);
        _parentUnitCompo.OnReturnTurn.AddListener(ReturnTurn);
        _itemManager = Parent.GetComponent<ItemManager>();
        _agentActCommander = Parent.GetComponent<AgentActCommander>();
    }
    public abstract void GetTurn();
    public abstract void ReturnTurn();
}
