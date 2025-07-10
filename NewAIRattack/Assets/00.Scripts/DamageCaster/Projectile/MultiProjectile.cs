using System.Collections.Generic;
using UnityEngine;

public class MultiProjectile : Projectile
{
    [SerializeField]
    private float _bulletPerAngle;
    [SerializeField]
    private List<Projectile> _projectiles = new List<Projectile>();
    private float _randomDir => Random.Range(-_bulletPerAngle, _bulletPerAngle);

    public override void Init(Vector3 startPos, Vector3 forwardDirection, float speedMultif)
    {
        foreach(Projectile projectile in _projectiles)
        {
            projectile.Init(startPos,Quaternion.Euler(_randomDir,_randomDir, _randomDir)*forwardDirection, speedMultif);
            projectile.transform.parent = null;
        }
        Destroy(gameObject);
    }
    public override void Update()
    {

    }
}
