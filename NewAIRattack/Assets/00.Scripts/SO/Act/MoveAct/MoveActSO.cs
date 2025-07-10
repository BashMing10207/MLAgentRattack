using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveActSO", menuName = "SO/Act/MoveActSO")]

public class MoveActSO : ActSO
{
    [SerializeField]
    private Vector3 _defaultVector = Vector3.zero;
    public override void RunAct(Vector3 dir,GetCompoParent agent)
    {
        
        dir = (dir+_defaultVector).normalized*dir.magnitude;
        Vector3 direction = dir * PlayerANDAgentStat(agent); //움직이는 것에 민첩이나 힘 등의 수치를 적용시킬 수 있다 ㅎㅎ
        agent.GetCompo<StonePhysics>().AddForce(direction);

    }
}
