using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSkillSO", menuName = "SO/Act/SummonSO/ProjectileSKillSO")]
public class ProjectileActSO : SummonActSO
{

    public override void RunAct(Vector3 dir, GetCompoParent agent)
    {

        Projectile projectile = Instantiate(Perfab,agent.transform.position,Quaternion.identity) as Projectile;

        projectile.Init(agent.transform.position+dir.normalized*(agent.transform.lossyScale.x+0.05f), dir.normalized, dir.magnitude * PlayerANDAgentStat(agent));// agent.GetCompo<AgentStat>().);
    }
}
