using UnityEngine;

public class SummonImpact : SummonedObject
{
    public override void Init(Vector3 a, Vector3 b, float stat)
    {
        transform.localScale *= 1+(b.magnitude*stat);

    }
}
