using UnityEngine;
[CreateAssetMenu(fileName = "StatActSO", menuName = "SO/Act/HeavyActSO")]
public class BeHeavyActSO : ActSO
{
    public override void RunAct(Vector3 dir, GetCompoParent agent)
    {
        agent.GetComponent<Rigidbody>().mass *= 1+dir.magnitude*StatModValue;

    }
}
