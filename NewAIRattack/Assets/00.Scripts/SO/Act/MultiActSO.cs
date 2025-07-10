using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StatActSO", menuName = "SO/Act/MultiActSO")]
public class MultiActSO : ActSO
{
    [SerializeField]
    private List<ActSO> _acts = new();
    public override void RunAct(Vector3 dir, GetCompoParent agent)
    {
        foreach (ActSO act in _acts)
        {
            act.RunAct(dir, agent);
        }
    }
    public override void EndAct(GetCompoParent agent)
    {
        foreach(ActSO act in _acts)
            { act.EndAct(agent); }
    }
}
