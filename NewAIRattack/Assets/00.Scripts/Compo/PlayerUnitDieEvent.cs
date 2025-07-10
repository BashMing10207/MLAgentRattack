using UnityEngine;

public class PlayerUnitDieEvent : MonoBehaviour, IGetCompoable,IAfterInitable
{
    private Unit _unit;

    public void AfterInit()
    {
        
    }

    public void Initialize(GetCompoParent entity)
    {
        _unit = entity as Unit;
    }

    public void OnDead()
    {
        
    }
}
