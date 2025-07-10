using UnityEngine;

public class SpeedModifyProjecitle : Projectile
{
    public override void Init(Vector3 forwardDirection, Vector3 startPos, float speedMultif)
    {
        base.Init(forwardDirection, startPos, speedMultif);
        _speedMulti = speedMultif;
    }
}
