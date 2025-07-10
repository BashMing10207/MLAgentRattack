using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour,IGetCompoable,IAfterInitable
{

    private GetCompoParent _parent;
    private PlayerAgentManager _agentManager;
    [SerializeField] private UnitGroup _currentSpawnUnits;
    [SerializeField] private List<UnitGroup> UnitGroups = new();

    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;
    }
    public void AfterInit()
    {
        _agentManager = _parent.GetCompo<PlayerAgentManager>();
    }

    public void AddUnitGroup()
    {
        if(UnitGroups.Count > 0)
        {
            _currentSpawnUnits.Units.AddRange(UnitGroups[0].Units);
            UnitGroups.RemoveAt(0);
        }
    }

    public void SpwanStone()
    {
        Summon(_currentSpawnUnits.Units[Random.Range(0,_currentSpawnUnits.Units.Count)]);
    }
    private void Summon(Unit unit)
    {
        _agentManager.AddStone(Instantiate(unit, _agentManager.SelectedUnit().transform.position+new Vector3(0,4,0),Quaternion.identity));
    }
}
