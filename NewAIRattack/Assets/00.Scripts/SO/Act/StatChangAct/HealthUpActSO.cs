using UnityEngine;

[CreateAssetMenu(fileName = "StatActSO", menuName = "SO/Act/HPActSO")]

public class HealthUpActSO : ActSO
{

    [SerializeField]
    private float _baseValue = -10,_howMuchaffectStat=0.1f;

    public override void RunAct(Vector3 dir, GetCompoParent agent)
    {
        agent.GetCompo<Health>().GetDamage(_baseValue*(1+_howMuchaffectStat* PlayerANDAgentStat(agent)));
    }
}
