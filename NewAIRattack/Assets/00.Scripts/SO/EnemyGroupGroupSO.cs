using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyGroup", menuName = "SO/EnemyGroup")]
public class EnemyGroupGroupSO : ScriptableObject
{
    public List<UnitGroup> Units = new(); 

    public Unit IndexOfUnit(int idx)
    {
        return Units[idx].Units[UnityEngine.Random.Range(0, Units[idx].Units.Count)];
    }
}
[Serializable]
public class UnitGroup
{
    public List<Unit> Units = new();
}