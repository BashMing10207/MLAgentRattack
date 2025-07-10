using UnityEngine;

public class SizeModifyProjectile : Projectile
{
    public override void Init(Vector3 forwardDirection, Vector3 startPos, float sizeMoidfy)
    {
        base.Init(forwardDirection, startPos, sizeMoidfy);
        _sizeModify = sizeMoidfy;
    }
}
