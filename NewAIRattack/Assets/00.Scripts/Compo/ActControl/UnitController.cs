using UnityEngine;

public abstract class UnitController : GetableCoponentBase, IAfterInitable
{
    protected Unit _parentUnitCompo;
    public void AfterInit()
    {
        _parentUnitCompo = (Unit)Parent;
        _parentUnitCompo.OnGetTurn.AddListener(GetTurn);
        _parentUnitCompo.OnReturnTurn.AddListener(ReturnTurn);
    }
    public abstract void GetTurn();
    public abstract void ReturnTurn();
}
